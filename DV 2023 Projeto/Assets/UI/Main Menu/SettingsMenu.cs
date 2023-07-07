using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject controlsPanel;

    public void ChangeVolume(double newVolume)
    {
        // TODO 
    }

    public void ChangeKeyBind()
    {
        // TODO 
    }

    public void ControlsSettings()
    {
        audioPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
    
    public void AudioSettings()
    {
        controlsPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
