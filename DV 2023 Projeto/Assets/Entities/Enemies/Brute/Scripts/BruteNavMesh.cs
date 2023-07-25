using System.Collections;
using System.Collections.Generic;
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

    private Animator animator;

    [SerializeField] private bool isScreaming;

    [SerializeField] private bool isAttacking;
    [SerializeField] private float dist;
    [SerializeField] private Vector3 curVelocity;
    [SerializeField] private float delay;

    [SerializeField] private float lastAttackTime = 0;
    [SerializeField] private float attackCooldown; //segundos
    [SerializeField] private float stoppingDistance;

    private void Start()
    {
        mainTargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentTargetTransform = mainTargetTransform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        attackCooldown = 2f;
        isScreaming = true;
        isAttacking = false;
        navMeshAgent.avoidancePriority = 0;

        gameEvents.OnPlayerDeath += OnPlayerDeath;
        gameEvents.OnPlayerRessurection += OnPlayerRessurection;
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

        Debug.Log("Start Attack");
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
}