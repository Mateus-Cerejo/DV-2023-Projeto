using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private GameObject respawnPoint;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = transform.GetChild(0).gameObject;
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (playerCharacter.activeSelf)
            {
                
                PlayerDeath();
            }
            else
            {
               
                PlayerRevive();
               
            }
           
        }
        
    }

    private void PlayerDeath()
    {
        playerCharacter.SetActive(false);
        gameEvents.InvokePlayerDied();
        Invoke("PlayerRevive", 10f);
    }


    private void PlayerRevive()
    {
        gameEvents.InvokePlayerRevived();

        characterController.enabled = false;
        gameObject.transform.position = respawnPoint.transform.position;
        gameObject.transform.rotation = respawnPoint.transform.rotation;
        characterController.enabled = true;
        playerCharacter.SetActive(true);

    }
}
