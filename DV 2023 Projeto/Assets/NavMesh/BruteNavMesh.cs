using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteNavMesh : MonoBehaviour
{
    [SerializeField] private Transform targetTransform; //
    [SerializeField] private float stoppingDistance;    //distância para parar

    private float lastAttackTime = 0;
    private float attackCooldown = 1; //segundos
    private bool screaming = false;

    private NavMeshAgent navMeshAgent; 
    private Animator animator;

    private void Awake()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StopEnemy();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, targetTransform.position);

        if(dist < stoppingDistance)
        {
            StopEnemy();
            if(Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;

            }
        }
        else if(!screaming)
        {
            GoToTarget();
        }
        //navMeshAgent.destination = targetTransform.position;
    }

    private void LateUpdate()
    {
        
    }

    private void StopEnemy()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        animator.SetBool("isRunning", false);
    }

    private void GoToTarget()
    {
        navMeshAgent.isStopped=false;
        navMeshAgent.SetDestination(targetTransform.position);
        animator.SetBool("isRunning", true);
    }
}
