using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject saves;

    public void Play()
    {
        saves.SetActive(true);
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Bye!");
        Application.Quit();
    }
} 
