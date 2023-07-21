using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
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
        }
    }
}
