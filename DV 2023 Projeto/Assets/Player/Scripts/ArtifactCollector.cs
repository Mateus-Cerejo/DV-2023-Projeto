using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtifactCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private float popupTime = 2.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artifact"))
        {
            popupText.text = "Picked Up:+" + other.GetComponent<ArtifactPickUp>().GetArtifactName() + "+";
            StartCoroutine(delayCleanText());
        }
    }

    private IEnumerator delayCleanText()
    {
        yield return new WaitForSeconds(popupTime);
        popupText.text = "";
    }
}
