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


    [SerializeField] private GameObject[] artifacts;
    [SerializeField] private ArtifactBackPack abp;

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

        spawnArtifact();

        Destroy(gameObject);
    }

    private void spawnArtifact()
    {
        int spawnArtifact = Mathf.RoundToInt(Random.value);
        if (spawnArtifact == 1)
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
}
