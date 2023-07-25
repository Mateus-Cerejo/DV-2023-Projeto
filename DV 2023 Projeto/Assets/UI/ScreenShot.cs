using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public KeyCode screenShotButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            Debug.Log("A screenshot was taken!");
        }
    }
}
