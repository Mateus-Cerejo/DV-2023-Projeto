using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class BruteNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform mainTargetTransform;
    [SerializeField] private Transform currentTargetTransform;

    [SerializeField] private GameEvents gameEvents;
    private AudioSource audioSource;
    [SerializeField] private AudioClip zombieScream;
    [SerializeField] private AudioClip zombieAttack;
    

    private Animator animator;

    [SerializeField] private bool isScreaming;

    [SerializeField] private bool isAttacking;
    [SerializeField] private float dist;
    [SerializeField] private Vector3 curVelocity;
    [SerializeField] private float delay;

    [SerializeField] private float lastAttackTime = 0;
    [SerializeField] private float attackCooldown; //segundos
    [SerializeField] private float stoppingDistance;

    //Attack Stats
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask layer;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackSweepArea;
    [SerializeField] private float attackHeightArea = 0f;
    [SerializeField] private float lightAttackDamage;
    [SerializeField] private float heavyAttackDamage;

    [SerializeField] private ArtifactBackPack abp;
    private float normalSpeed = 7.0f;
    private bool isFrozen = false;



    private void Start()
    {
        mainTargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentTargetTransform = mainTargetTransform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        stoppingDistance = 2f;

        attackCooldown = 2f;
        isScreaming = true;
        isAttacking = false;
        navMeshAgent.avoidancePriority = 0;

        gameEvents.OnPlayerDeath += OnPlayerDeath;
        gameEvents.OnPlayerRessurection += OnPlayerRessurection;

        normalSpeed = navMeshAgent.speed;
    }

    private void Update()
    {
        dist = Vector3.Distance(transform.position, currentTargetTransform.position);
        //Debug.Log("Distance" + dist);
        //Debug.Log("Velocity" + navMeshAgent.velocity);

        //Debug.Log("CooldownTimer" + (Time.time - lastAttackTime));

        if (dist <= stoppingDistance)
        {
            animator.SetBool("isRunning", false);
            if ((Time.time - lastAttackTime >= attackCooldown) && !isAttacking)
            {
                lastAttackTime = Time.time;
                Attack();
                //Debug.Log("Attack");
            }
            else if (!isAttacking)
            {
                //Debug.Log("Stop");
                Stop();
            }


        }
        else if (!isScreaming && !isAttacking)
        {
            //Debug.Log("Chase");
            Chase();
        }
        //navMeshAgent.destination = targetTransform.position;
    }


    private void Stop()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        // Calculate the direction to face without tilting
        Vector3 targetDirection = currentTargetTransform.position - transform.position;
        targetDirection.y = 0f;

        // Use Quaternion.LookRotation to face the target direction
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = targetRotation;
        }
    }

    private void Chase()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(currentTargetTransform.position);
        animator.SetBool("isRunning", true);
    }

    private void Attack()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        int attackType = Random.Range(0, 10);
        animator.SetBool("isAttacking", true);
        animator.SetInteger("attackType", attackType);
        isAttacking = true;
    }

    private void startAttack()
    {
        audioSource.PlayOneShot(zombieAttack);
        audioSource.PlayOneShot(zombieAttack);
    }

    private void endAttack()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
        lastAttackTime = Time.time;
        Debug.Log("End Attack");
    }

    private void startScreaming()
    {
        audioSource.PlayOneShot(zombieScream);
    }

    private void stopScreaming()
    {
        isScreaming = false;
    }

    private void OnPlayerDeath()
    {
        currentTargetTransform = GameObject.FindGameObjectWithTag("Gate").transform;
    }

    private void OnPlayerRessurection()
    {
        currentTargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void SpawnLightHurtBox()
    {
        Vector3 boxSize = new Vector3(attackSweepArea, attackHeightArea, attackRange);

        Collider[] objectsHit = Physics.OverlapBox(attackPoint.position, boxSize / 2f, attackPoint.rotation, layer);
        foreach (Collider objectHit in objectsHit)
        {
            if (objectHit.gameObject.layer == 31) //Player layer at position 31
            {
                objectHit.gameObject.GetComponent<PlayerStats>().TakeDamage(lightAttackDamage);
            }
            if (objectHit.gameObject.layer == 9) //obstacle(barrier) layer at position 9
            {
                objectHit.gameObject.GetComponent<ObstacleHealth>().TakeDmg(lightAttackDamage);
            }
        }
    }

    private void SpawnHeavytHurtBox()
    {
        Vector3 boxSize = new Vector3(attackSweepArea + 0.75f, attackHeightArea, attackRange * 1.5f);

        Collider[] objectsHit = Physics.OverlapBox(attackPoint.position, boxSize / 2f, attackPoint.rotation, layer);
        foreach (Collider objectHit in objectsHit)
        {
            if (objectHit.gameObject.layer == 31) //Player layer at position 31
            {
                objectHit.gameObject.GetComponent<PlayerStats>().TakeDamage(heavyAttackDamage);
            }
            if (objectHit.gameObject.layer == 9) //obstacle(barrier) layer at position 9
            {
                objectHit.gameObject.GetComponent<ObstacleHealth>().TakeDmg(heavyAttackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Handles.color = Color.red;
        Handles.matrix = Matrix4x4.TRS(attackPoint.position, attackPoint.rotation, Vector3.one);
        Handles.DrawWireCube(Vector3.zero, new Vector3(attackSweepArea, attackHeightArea, attackRange));
    }

    public void ApplyFreezeEffect()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            navMeshAgent.speed = normalSpeed - normalSpeed * abp.iceAuraArtifactEffect;
            Invoke("RevertFreezeEffect", abp.iceAuraArtifactDuration);
        }
    }

    public void RevertFreezeEffect()
    {
        if (isFrozen)
        {
            isFrozen = false;
            navMeshAgent.speed = normalSpeed;

        }
    }
}