using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class PlayerMeleeSystem : MonoBehaviour
{
    //[SerializeField] private Animator animator;

    [SerializeField] private TextMeshProUGUI weaponNameText;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackSweepArea;
    [SerializeField] private float attackHeightArea=0f;

    [SerializeField] private ArtifactBackPack abp;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRate;
    private float nextAttackTime;

    [SerializeField] private bool canOverHeat = false;
    [SerializeField] private float maxOverHeat = 1.0f;
    [SerializeField] private float heatIncrement = 0.0f;
    [SerializeField] private float heatDecrement = 0.0f;
    private float currentHeat = 0.0f;
    private bool overHeated = false;
    [SerializeField] private Image overHeatRadialImage;

    [SerializeField] private AudioSource idleAudioSource;
    [SerializeField] private AudioSource swingOrRevAudioSource;

    [SerializeField] private GameObject enemyHitGraphic;

    void Awake() {
        attackDamage *= PlayerPrefs.GetFloat("attackBonus", 1);
        overHeatRadialImage.gameObject.SetActive(false);
        weaponNameText.text = gameObject.name;
    }

    void OnDisable() {
        overHeatRadialImage.gameObject.SetActive(false);
    }

    void OnEnable() {
        overHeatRadialImage.gameObject.SetActive(true);
        weaponNameText.text = gameObject.name;
    }

    void FixedUpdate()
    {
        if (idleAudioSource != null && !idleAudioSource.isPlaying)
        {
            idleAudioSource.Play();
        }
        OverHeatIndicator();
        if(canOverHeat && currentHeat>0 && !Input.GetButton("Fire1") && !overHeated)
        {
            currentHeat -= heatDecrement;
            if(currentHeat<=0)
            {
                currentHeat=0;
                overHeated=false;
            }
        }
        if(overHeated)
        {
            currentHeat -= heatDecrement;
            if(currentHeat<=0)
            {
                currentHeat=0;
                overHeated=false;
            }
        }
        if(Time.time >= nextAttackTime && !overHeated){
            if(Input.GetButton("Fire1"))
            { 
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
            
        }
    }

    private void Attack()
    {
        if (swingOrRevAudioSource != null && !swingOrRevAudioSource.isPlaying)
        {
            swingOrRevAudioSource.Play();
        }

        Vector3 boxSize = new Vector3(attackSweepArea, attackHeightArea, attackRange);
        Quaternion rotation = fpsCam.transform.rotation;
        Vector3 position = attackPoint.position;

        Collider[] hitEnemies = Physics.OverlapBox(position, boxSize / 2f, rotation);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.GetComponent<BruteStats>() != null)
            {
                enemy.GetComponent<BruteStats>().TakeDamage(attackDamage + attackDamage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + attackDamage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                Debug.Log("Hit melee brute");
                Destroy(Instantiate(enemyHitGraphic, enemy.gameObject.transform.position + new Vector3(0, 1.5f, 0), Quaternion.LookRotation(enemy.gameObject.transform.position)), 1.0f);
            }
            else if (enemy.GetComponent<ZombieStats>() != null)
            {
                enemy.GetComponent<ZombieStats>().TakeDamage(attackDamage + attackDamage * abp.powerArtifactQuantityEquiped * abp.powerArtifactEffect + attackDamage * abp.allInOneArtifactQuantityEquiped * abp.allInOneArtifactEffect);
                Debug.Log("Hit melee zombie");
                Destroy(Instantiate(enemyHitGraphic, enemy.gameObject.transform.position + new Vector3(0,1.5f,0), Quaternion.LookRotation(enemy.gameObject.transform.position)), 1.0f);
            }
        }
        if (canOverHeat)
        {
            currentHeat += heatIncrement;
            if(currentHeat>=maxOverHeat)
            {
                overHeated=true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
         if (attackPoint == null)
        {
            return;
        }

        Handles.color = Color.red;
        Handles.matrix = Matrix4x4.TRS(attackPoint.position, fpsCam.transform.rotation, Vector3.one);
        Handles.DrawWireCube(Vector3.zero, new Vector3(attackSweepArea, attackHeightArea, attackRange));
    }

    private void OverHeatIndicator()
    {
        // Update the reload progress in the Radial Image
        overHeatRadialImage.fillAmount = Mathf.Clamp01(currentHeat / maxOverHeat);
    }
}
