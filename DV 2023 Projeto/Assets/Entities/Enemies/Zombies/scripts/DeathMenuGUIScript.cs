using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathMenuGUIScript : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private TextMeshProUGUI respawnMessage;
    [SerializeField] private TextMeshProUGUI deathMessage;
    private float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.OnPlayerDeath += OnPlayerDeath;
        gameEvents.OnPlayerRessurection += OnPlayerRessurection;
        respawnTimer = 10f;
        respawnMessage.enabled = false;
        deathMessage.enabled = false;
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
        respawnTimer = 10f;
    }
}
