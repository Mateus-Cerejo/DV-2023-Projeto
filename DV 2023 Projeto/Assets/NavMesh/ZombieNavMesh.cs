using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ZombieNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject mainTarget;
    [SerializeField] private Transform currentTargetTransform;

    [SerializeField] private FieldOfView fov;

    private Animator animator;

    [SerializeField] private bool isAttacking;
    [SerializeField] private float dist;
    [SerializeField] private Vector3 curVelocity;
    [SerializeField] private float delay;

    [SerializeField] private float lastAttackTime = 0;
    [SerializeField] private float attackCooldown; //segundos
    [SerializeField] private float stoppingDistance;

    void Start()
    {
        //mainTargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isAttacking = false;
        attackCooldown = 5f;
        stoppingDistance = 1.5f;
        delay = 0.2f;

        fov = GetComponent<FieldOfView>();
        mainTarget = GameObject.FindGameObjectWithTag("Gate");

        currentTargetTransform = mainTarget.transform;
        StartCoroutine("FindTargetsWithDelay", delay);

    }

    private IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("In Enum");

            Transform target = fov.FindVisibleTargets();
            Debug.Log(target);
            currentTargetTransform = target != null
                    ? target
                    : mainTarget.transform;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        curVelocity = navMeshAgent.velocity;
        Vector3 targetGroundDistance = new Vector3(currentTargetTransform.position.x, 0, currentTargetTransform.position.z);
        dist = Vector3.Distance(transform.position, currentTargetTransform.position);
        //Debug.Log("Distance" + dist);
        //Debug.Log("Velocity" + navMeshAgent.velocity);
        //Debug.Log(Time.deltaTime - lastAttackTime);

        //SOLUÇÃO TEMPORÁRIA
        //Current Target é destruído
        currentTargetTransform = currentTargetTransform == null
                ? mainTarget.transform
                : currentTargetTransform;

        if(dist <= stoppingDistance)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            if ((Time.time - lastAttackTime >= attackCooldown) && !isAttacking)
            {
                lastAttackTime = Time.time;
                Attack();
                
            }
            else if (!isAttacking) 
            {
                Stop();
            }
        }
        else if(!isAttacking)
        {
            Chase();
        }

    }

    private void Stop()
    {
        //INICIAL
        /*
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        Vector3 targetDirection = new Vector3(currentTargetTransform.position.x, currentTargetTransform.position.y, 0);

        transform.LookAt(currentTargetTransform.position);
        */

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
        //Vector3 targetDirection = new Vector3(currentTargetTransform.position.x, currentTargetTransform.position.y, 0);
        navMeshAgent.SetDestination(currentTargetTransform.position);
        animator.SetBool("isWalking", true);
    }

    private void Attack()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        animator.SetBool("isAttacking", true);
        isAttacking = true;
    }

    private void startAttack()
    {
        
        //Debug.Log("Start Attack");
    }

    private void endAttack()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
        lastAttackTime = Time.time;
        //Debug.Log("End Attack");
    }

}
