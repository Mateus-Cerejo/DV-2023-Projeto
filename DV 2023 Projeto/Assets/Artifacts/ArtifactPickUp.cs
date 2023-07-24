using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArtifactPickUp : MonoBehaviour
{
    [SerializeField] private string artifactName; 
    [SerializeField] private ArtifactBackPack abp;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(artifactName=="power") abp.collectPowerArtifact();
            if(artifactName=="speed") abp.collectSpeedArtifact();
            if(artifactName=="life") abp.collectLifeArtifact();
            if(artifactName=="looter") abp.collectLooterArtifact();
            if(artifactName=="allInOne") abp.collectAllInOneArtifact();
            if(artifactName=="iceAura") abp.collectIceAuraArtifact();
            StartCoroutine(delayDestroy());
        }
    }
    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    public string GetArtifactName() => artifactName;
}
