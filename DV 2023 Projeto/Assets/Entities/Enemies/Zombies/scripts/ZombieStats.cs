using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static GameEvents;

public class ZombieStats : MonoBehaviour
{
    private Animator animator;
    private ZombieNavMesh characterMovement;
    private FieldOfView characterFov;
    [SerializeField] private GameEvents gameEvents;

    [SerializeField] private int curHealth;
    [SerializeField] private int zombiesCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<ZombieNavMesh>();
        characterFov = GetComponent<FieldOfView>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        characterMovement.enabled = false;
        characterFov.enabled = false;

        gameEvents.InvokeEnemyDied(zombiesCount);

        Destroy(gameObject);
    }

}
