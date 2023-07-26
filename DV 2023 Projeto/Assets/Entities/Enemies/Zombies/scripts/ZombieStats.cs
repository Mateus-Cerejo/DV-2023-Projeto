using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static GameEvents;

public class ZombieStats : MonoBehaviour
{
    private Animator animator;
    private ZombieNavMesh characterMovement;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private FieldOfView characterFov;
    [SerializeField] private GameEvents gameEvents;

    [SerializeField] private AudioClip zombieHitSound;
    [SerializeField] private AudioClip zombieDeathSound;

    [SerializeField] private float curHealth;
    [SerializeField] private int zombiesCount;

    [SerializeField] private GameObject[] artifacts;
    [SerializeField] private ArtifactBackPack abp;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<ZombieNavMesh>();
        characterFov = GetComponent<FieldOfView>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
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
        GetComponent<BoxCollider>().enabled = false;

        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        audioSource.PlayOneShot(zombieDeathSound);

        gameEvents.InvokeEnemyDied(zombiesCount);

        spawnArtifact();

        Invoke("Destroy", 3f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void spawnArtifact()
    {
        int spawnArtifact = Random.Range(0, 100);//Mathf.RoundToInt(Random.value);

        if (spawnArtifact > 95)
        {
            if (abp.iceAuraArtifactQuantityStored < 1)
            {
                float artifactToSpawn = Random.Range(0, 89);
                if (artifactToSpawn < 25) Instantiate(artifacts[0], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 25 && artifactToSpawn < 50) Instantiate(artifacts[1], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 50 && artifactToSpawn < 75) Instantiate(artifacts[2], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 75 && artifactToSpawn < 85) Instantiate(artifacts[3], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 85 && artifactToSpawn < 87) Instantiate(artifacts[4], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 87) Instantiate(artifacts[5], transform.position, Quaternion.identity);
            }
            else
            {
                float artifactToSpawn = Random.Range(0, 87);
                if (artifactToSpawn < 25) Instantiate(artifacts[0], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 25 && artifactToSpawn < 50) Instantiate(artifacts[1], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 50 && artifactToSpawn < 75) Instantiate(artifacts[2], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 75 && artifactToSpawn < 85) Instantiate(artifacts[3], transform.position, Quaternion.identity);
                if (artifactToSpawn >= 85) Instantiate(artifacts[4], transform.position, Quaternion.identity);
            }
        }
    }



    public void TakeDamage(float damage)
    {
        if (curHealth > 0)
        {
            curHealth -= damage;
            if (abp.iceAuraArtifactQuantityEquiped >= 1) characterMovement.ApplyFreezeEffect();
            if (curHealth <= 0) Die();
            else audioSource.PlayOneShot(zombieHitSound);
        }
    }

}
