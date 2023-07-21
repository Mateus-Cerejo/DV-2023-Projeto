using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
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
                        PlayerPrefs.SetInt("factoryNumOfItems", 3);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("factoryNumOfItems", 5);
                    }
                    break;
            }
        }
    }
}
