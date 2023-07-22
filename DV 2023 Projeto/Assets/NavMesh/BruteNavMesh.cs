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
    private float attackCooldown; //segundos
    private bool screaming;
    [SerializeField] private bool isAttacking;

    [SerializeField] private float dist; // APAGAR DEPOIS

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        attackCooldown = 2f;
        screaming = false;
        isAttacking = false;
        navMeshAgent.avoidancePriority = 0;
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
            if ((Time.time - lastAttackTime >= attackCooldown) && !isAttacking)
            {
                lastAttackTime = Time.time;
                Attack();
                Debug.Log("Attack");
            }
            else if (!isAttacking)
            {
                Debug.Log("Stop");
                StopEnemy();
            }


        }
        else if (!screaming && !isAttacking)
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
}