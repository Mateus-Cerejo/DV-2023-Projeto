using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitation : MonoBehaviour
{
    private UpgradableBuilding upgBuild;

    private void Start()
    {
        upgBuild = gameObject.GetComponent<UpgradableBuilding>();    
    }

    public void Upgrade()
    {
        if (upgBuild.Upgrade())
        {
            switch (upgBuild.GetCurLevel())
            {
                case 1:
                    {
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax", 0) + 50);
                        PopulationManager.Instance.AddOrSubMaxPopulation(50);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("populationMax", PlayerPrefs.GetInt("populationMax") + 100);
                        PopulationManager.Instance.AddOrSubMaxPopulation(100);
                    }
                    break;
            }
        }
    }
}
