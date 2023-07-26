using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.active);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
