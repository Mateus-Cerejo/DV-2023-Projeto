using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth;
    [SerializeField] private float chipSpeed = 2f;
    [SerializeField] private Image frontHealthBar;
    [SerializeField] private Image backHealthBar;
    private float lerpTimer;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
        updateHealthUI();
        if(Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(Random.Range(5,10));
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            heal(Random.Range(5,10));
        }
    }

    private void updateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth/maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer = Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB,hFraction,percentComplete);
        }
        if(fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer = Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF,backHealthBar.fillAmount,percentComplete);
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
}
