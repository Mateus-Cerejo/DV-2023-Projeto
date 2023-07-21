using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class BruteNavMesh : MonoBehaviour
{
    [SerializeField] private Transform targetTransform; //
    [SerializeField] private float stoppingDistance;    //distância para parar

    [SerializeField] private float lastAttackTime = 0;
    private float attackCooldown = 3f; //segundos
    private bool screaming = false;
    [SerializeField] private bool attacking = false;

    [SerializeField] private float dist = 100; // APAGAR DEPOIS

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.avoidancePriority = 0;
        StopEnemy();
    }

    private void Update()
    {
        dist = Vector3.Distance(transform.position, targetTransform.position);
        Debug.Log("Distance" + dist);
        Debug.Log("Velocity" + navMeshAgent.velocity);

        Debug.Log("CooldownTimer" + (Time.time - lastAttackTime));

        if (dist < stoppingDistance)
        {
            animator.SetBool("isRunning", false);
            if ((Time.time - lastAttackTime >= attackCooldown) && !attacking)
            {
                lastAttackTime = Time.time;
                Attack();
                Debug.Log("Attack");
            }
            else if (!attacking)
            {
                Debug.Log("Stop");
                StopEnemy();
            }


        }
        else if (!screaming && !attacking)
        {
            Debug.Log("Chase");
            GoToTarget();
        }
        //navMeshAgent.destination = targetTransform.position;
    }
    /*
    private void LateUpdate()
    {
        float dist = Vector3.Distance(transform.position, targetTransform.position);
    }
    */

    private void StopEnemy()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
        transform.LookAt(targetTransform);
    }

    private void GoToTarget()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(targetTransform.position);
        animator.SetBool("isRunning", true);
    }

    private void Attack()
    {
        
        int attackType = Random.Range(0, 10);
        animator.SetTrigger("attack");
        animator.SetInteger("attackType", attackType);
    }

    private void startAttack()
    {
        attacking = true;      
        Debug.Log("Start Attack");
    }

    private void endAttack()
    {
        attacking = false;
        Debug.Log("End Attack");
    }
}