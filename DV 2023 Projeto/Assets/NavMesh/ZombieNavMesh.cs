using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ZombieNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform mainTargetTransform;

    private Animator animator;

    [SerializeField] private bool isAttacking;
    [SerializeField] private float dist;

    [SerializeField] private float lastAttackTime = 0;
    [SerializeField] private float attackCooldown; //segundos
    [SerializeField] private float stoppingDistance;

    void Start()
    {
        mainTargetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isAttacking = false;
        attackCooldown = 5f;
        stoppingDistance = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, mainTargetTransform.position);
        //Debug.Log("Distance" + dist);
        //Debug.Log("Velocity" + navMeshAgent.velocity);
        //Debug.Log(Time.time - lastAttackTime);

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
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        transform.LookAt(mainTargetTransform);
        
    }

    private void Chase()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(mainTargetTransform.position);
        animator.SetBool("isWalking", true);
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
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
