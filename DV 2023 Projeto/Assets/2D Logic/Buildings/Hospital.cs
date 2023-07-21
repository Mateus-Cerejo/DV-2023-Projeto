using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
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
                        PlayerPrefs.SetInt("revivingSpeedPerc", 25);
                    }
                    break;
                case 2:
                    {
                        PlayerPrefs.SetInt("revivingSpeedPerc", 50);
                    }
                    break;
            }
        }
    }
}
