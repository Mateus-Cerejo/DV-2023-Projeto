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
        //curLevel = PlayerPrefs.GetInt("Hab1");
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }

    public void UpgradeMarket() {
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }
    public void UpgradeHospital() {
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }
    public void UpgradeFactory() {
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }

    public void UpgradeFarm() {
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }
    public void UpgradeLab() {
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
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 50);
                    }
                    break;
            }
        }
    }
}
