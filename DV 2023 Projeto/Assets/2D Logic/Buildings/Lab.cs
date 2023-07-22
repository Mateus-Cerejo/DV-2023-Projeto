using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
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
        }
    }
}
