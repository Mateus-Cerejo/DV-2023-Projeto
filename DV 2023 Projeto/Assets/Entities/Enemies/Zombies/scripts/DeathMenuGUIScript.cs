using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuGUIScript : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private TextMeshProUGUI respawnMessage;
    [SerializeField] private TextMeshProUGUI deathMessage;
    [SerializeField] private TextMeshProUGUI gameOverMessage;
    [SerializeField] private GameObject buttonOptions;
    [SerializeField] private GameObject weaponHolder;
    private float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.OnPlayerDeath += OnPlayerDeath;
        gameEvents.OnPlayerRessurection += OnPlayerRessurection;
        gameEvents.OnEnemyBreach += OnEnemyBreach;
        respawnTimer = 5f;
        respawnMessage.enabled = false;
        deathMessage.enabled = false;
        gameOverMessage.enabled = false;
        buttonOptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnMessage.enabled)
        {
            respawnTimer -= Time.deltaTime;
            respawnMessage.text = "Respawn in " + (int)respawnTimer;
        }      
    }

    private void OnPlayerDeath()
    {
        respawnMessage.enabled = true;
        deathMessage.enabled = true;
    }

    private void OnPlayerRessurection()
    {
        respawnMessage.enabled = false;
        deathMessage.enabled = false;
        respawnTimer = 5f;
    }

    private void OnEnemyBreach()
    {
        Debug.LogWarning("EnemyBreached");
        Invoke("CheckGameOver", 0.5f);
    }

    private void CheckGameOver()
    {
        Debug.LogWarning("Population " + PlayerPrefs.GetInt("curPopulation"));
        if (PlayerPrefs.GetInt("curPopulation") <= 0)
        {
            gameOverMessage.enabled = true;
            buttonOptions.SetActive(true);
            respawnMessage.enabled = false;
            deathMessage.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            weaponHolder.SetActive(false);
            GameObject.Find("PcCamera").GetComponent<AudioListener>().enabled = false;
            Time.timeScale = 0;
        }
    }

    public void GoToTitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main menu");
    }
}
