using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Shop shop;

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
                        PlayerPrefs.SetInt("FactoryNumOfItems", 2);
                        PlayerPrefs.SetInt("FactoryNumOfItems", 2);
                        shop.RefreshShop();
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("FactoryNumOfItems", 3);
                        shop.RefreshShop();
                    }
                    break;
            }
        }
    }
}
