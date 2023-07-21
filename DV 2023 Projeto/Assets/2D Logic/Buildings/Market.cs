using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
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
                        PlayerPrefs.SetInt("MarketNumOfItems", 3);
                        shop.RefreshShop();
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("MarketNumOfItems", 5);
                        PlayerPrefs.SetInt("MarketDiscountPerc", PlayerPrefs.GetInt("marketDiscountPerc", 0) + 20);
                        shop.RefreshShop();
                    }
                    break;
            }
        }
    }
}
