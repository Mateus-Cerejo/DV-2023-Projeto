using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
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
                        PlayerPrefs.SetInt("populationPerRound", PlayerPrefs.GetInt("populationPerRound", 0) + 50);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("populationPerRound", PlayerPrefs.GetInt("populationPerRound", 0) + 150);
                    }
                    break;
            }
        }
    }
}
