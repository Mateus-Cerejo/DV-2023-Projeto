using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GunV2[] rangedWeapons;
    [SerializeField] private PlayerMeleeSystem[] meleeWeapons;

    [SerializeField] private int currentRangedIndex = 0;
    [SerializeField] private int currentMeleeIndex = 0;

    private void Start()
    {
        // Make sure to assign the appropriate scripts to the public variables
        // You can do this in the Inspector by dragging the corresponding GameObjects with the scripts attached.

        EnableRangedWeapon(currentRangedIndex);
    }

    private void Update()
    {
        HandleWeaponSwitching();
    }

    private void HandleWeaponSwitching()
    {
        if(!rangedWeapons[GetCurrentRangedWeapon()].IsReloading()){
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Switch to melee weapon
                EnableMeleeWeapon(currentMeleeIndex);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Switch to ranged weapon
                EnableRangedWeapon(currentRangedIndex);
            }
        }
    }

    private void EnableMeleeWeapon(int index)
    {
        // Disable all ranged weapon scripts
        for (int i = 0; i < rangedWeapons.Length; i++)
        {
            rangedWeapons[i].gameObject.SetActive(false);
        }

        // Disable all melee weapon scripts and enable the selected one
        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            meleeWeapons[i].gameObject.SetActive(i == index);
        }
    }

    private void EnableRangedWeapon(int index)
    {
        // Disable all melee weapon scripts
        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            meleeWeapons[i].gameObject.SetActive(false);
        }

        // Disable all ranged weapon scripts and enable the selected one
        for (int i = 0; i < rangedWeapons.Length; i++)
        {
            rangedWeapons[i].gameObject.SetActive(i == index);
        }
    }

    public void SetRangedWeapon(int i)
    {
        if(i < rangedWeapons.Length)
        {
            currentRangedIndex=i;
        }
    }

    public int GetCurrentRangedWeapon()
    {
        return currentRangedIndex;
    }

    public void SetMeleeWeapon(int i)
    {
        if(i < meleeWeapons.Length)
        {
            currentMeleeIndex=i;
        }
    }

    public int GetCurrentMeleeWeapon()
    {
        return currentMeleeIndex;

    }
}
