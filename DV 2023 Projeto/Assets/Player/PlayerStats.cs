using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private ArtifactBackPack abp;
    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth;
    [SerializeField] private float chipSpeed = 2f;
    [SerializeField] private Image frontHealthBar;
    [SerializeField] private Image backHealthBar;
    private float lerpTimer;
    
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private GameObject playerCharacter;
    private GameObject respawnPoint;
    private CharacterController characterController;

    void Awake()
    {
        maxHealth += maxHealth * abp.lifeArtifactQuantityEquiped * abp.lifeArtifactEffect + maxHealth * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect;
        currentHealth = maxHealth;
    }
    void Start()
    {
        playerCharacter = transform.GetChild(0).gameObject;
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        updateHealthUI();
        if (Input.GetKeyDown(KeyCode.I))
        {
            takeDamage(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            heal(Random.Range(5, 10));
        }

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

    private void updateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer = Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer = Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        lerpTimer = 0f;
    }

    public void heal(float value)
    {
        currentHealth += value;
        lerpTimer = 0f;
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
