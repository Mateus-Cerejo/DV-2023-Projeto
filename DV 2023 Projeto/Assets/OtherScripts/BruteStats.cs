using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteStats : MonoBehaviour
{
    private Animator animator;
    private BruteNavMesh characterMovement;
    [SerializeField] private GameEvents gameEvents;

    [SerializeField] private int curHealth;
    [SerializeField] private int zombiesCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<BruteNavMesh>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        characterMovement.enabled = false;

        gameEvents.InvokeEnemyDied(zombiesCount);

        Destroy(gameObject);
    }
}
