using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool active = false;
    public static PauseMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            pauseMenu.SetActive(active);
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
