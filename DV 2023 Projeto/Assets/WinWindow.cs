using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWindow : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
