using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private BuildingSO levels;
    [SerializeField] private MaterialsManager playerResources;
    [SerializeField] private GameObject actionBox;

    private GameObject building;
    private int curLevel = 0;

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(gameObject.name, 0);
        building = Instantiate(levels.getLevels()[curLevel], transform.position, transform.rotation, transform);
    }

     public bool Upgrade()
    {
        if (curLevel + 1 < levels.getNumOfLevels())
        {
            if (playerResources.Buy(levels.getLevelCosts()[curLevel]))
            {
                Destroy(building);
                building = Instantiate(levels.getLevels()[++curLevel], transform.position, transform.rotation, transform);
                CloseActionBox();
                return true;
            }
        }
        return false;
    }

    public void OpenActionBox()
    {
        actionBox.GetComponent<ActionBox>().Open(curLevel, levels, this);
        actionBox.SetActive(true);
    }

    public void CloseActionBox()
    {
        actionBox.SetActive(false);
    }

    public void UpgradeHabitation()
    {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax", 0) + 50);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 100);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }

    public void UpgradeMarket() {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("marketNumOfItems", 3);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("marketNumOfItems", 5);
                        PlayerPrefs.SetInt("marketDiscountPerc", PlayerPrefs.GetInt("marketDiscountPerc", 0) + 20);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }

    public void UpgradeHospital() {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("revivingSpeedPerc", 25);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("revivingSpeedPerc", 50);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }

    public void UpgradeFactory() {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("factoryNumOfItems", 3);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("factoryNumOfItems", 5);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }

    public void UpgradeFarm() {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("populationPerRound", PlayerPrefs.GetInt("populationPerRound", 0) + 50);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("populationPerRound", PlayerPrefs.GetInt("populationPerRound", 0) + 150);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }

    public void UpgradeLab() {
        if (Upgrade())
        {
            switch (curLevel)
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("researchPerRound", PlayerPrefs.GetInt("researchPerRound", 0) + 5);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("researchPerRound", PlayerPrefs.GetInt("researchPerRound", 0) + 5);
                    }
                    break;
                case 3:
                    {
                        PlayerPrefs.SetInt("researchPerRound", PlayerPrefs.GetInt("researchPerRound", 0) + 5);
                    }
                    break;
                case 4:
                    {
                        PlayerPrefs.SetInt("researchPerRound", PlayerPrefs.GetInt("researchPerRound", 0) + 5);
                    }
                    break;
            }
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name, 0) + 1);
        }
    }
}
