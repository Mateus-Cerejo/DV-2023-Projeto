using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 50f;
    [SerializeField] private float movementSpeed = 1.0f;
    private bool isFrozen = false;
    [SerializeField] private GameObject[] artifacts;
    [SerializeField] private ArtifactBackPack abp;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movementSpeed, 0, 0);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (abp.iceAuraArtifactQuantityEquiped >= 1 && !isFrozen)
        {
            StartCoroutine(slowEnemyCoroutine());
        }

        if(health<=0){
            Die();
        }
    }

    private IEnumerator slowEnemyCoroutine()
    {
        isFrozen = true;
        float originalSpeed = movementSpeed;
        movementSpeed /= abp.iceAuraArtifactEffect;

        yield return new WaitForSeconds(abp.iceAuraArtifactDuration);

        movementSpeed = originalSpeed;
        isFrozen = false;
    }

    private void Die()
    {
        spawnArtifact();
        Destroy(gameObject);
    }

    private void spawnArtifact()
    {
        int spawnArtifact = Mathf.RoundToInt(Random.value);
        if(spawnArtifact==1)
        {
            if(abp.iceAuraArtifactQuantityStored<1)
            {
                float artifactToSpawn = Random.Range(0,89);
                if(artifactToSpawn<25) Instantiate(artifacts[0], transform.position , Quaternion.identity);
                if(artifactToSpawn>=25&&artifactToSpawn<50) Instantiate(artifacts[1], transform.position , Quaternion.identity);
                if(artifactToSpawn>=50&&artifactToSpawn<75) Instantiate(artifacts[2], transform.position , Quaternion.identity);
                if(artifactToSpawn>=75&&artifactToSpawn<85) Instantiate(artifacts[3], transform.position , Quaternion.identity);
                if(artifactToSpawn>=85&&artifactToSpawn<87) Instantiate(artifacts[4], transform.position , Quaternion.identity);
                if(artifactToSpawn>=87) Instantiate(artifacts[5], transform.position , Quaternion.identity);
            }
            else
            {
                float artifactToSpawn = Random.Range(0,87);
                if(artifactToSpawn<25) Instantiate(artifacts[0], transform.position , Quaternion.identity);
                if(artifactToSpawn>=25&&artifactToSpawn<50) Instantiate(artifacts[1], transform.position , Quaternion.identity);
                if(artifactToSpawn>=50&&artifactToSpawn<75) Instantiate(artifacts[2], transform.position , Quaternion.identity);
                if(artifactToSpawn>=75&&artifactToSpawn<85) Instantiate(artifacts[3], transform.position , Quaternion.identity);
                if(artifactToSpawn>=85) Instantiate(artifacts[4], transform.position , Quaternion.identity);
            }
        }
    }
}
