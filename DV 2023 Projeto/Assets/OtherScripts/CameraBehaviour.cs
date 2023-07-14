using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject pcCamera;
    [SerializeField] private GameObject pcCamera_2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cam1"))
        {
            mainCamera.SetActive(true);
            pcCamera.SetActive(false);
            pcCamera_2.SetActive(false);
        }
        else if (Input.GetButtonDown("Cam2"))
        {
            mainCamera.SetActive(false);
            pcCamera.SetActive(true);
            pcCamera_2.SetActive(false);
        }
        else if (Input.GetButtonDown("Cam3"))
        {
            mainCamera.SetActive(false);
            pcCamera.SetActive(false);
            pcCamera_2.SetActive(true);
        }

    }
}
