using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeBtnText;
    [SerializeField] private TextMeshProUGUI costWood;
    [SerializeField] private TextMeshProUGUI costStone;
    [SerializeField] private TextMeshProUGUI costMetal;
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private GameObject focusPanel;

    public void Open(int curLevel, BuildingSO buildingSO, UpgradableBuilding upBuilding)
    {
        if (curLevel +1 == buildingSO.getNumOfLevels())
        {
            upgradeBtnText.SetText("Max LVL " + (curLevel + 1) + "/" + buildingSO.getNumOfLevels());
            costWood.SetText("---");
            costStone.SetText("---");
            costMetal.SetText("---");
            statsText.SetText("---");
        }
        else
        {
            upgradeBtnText.SetText("Upgrade " + (curLevel+1) + "/" + buildingSO.getNumOfLevels());

            costWood.SetText("" + buildingSO.getLevelCosts()[curLevel].GetWood());
            costStone.SetText("" + buildingSO.getLevelCosts()[curLevel].GetStone());
            costMetal.SetText("" + buildingSO.getLevelCosts()[curLevel].GetMetal());

            statsText.SetText(buildingSO.GetUpgradeText()[curLevel]);
        }
    }

    private void OnEnable()
    {
        focusPanel.SetActive(true);
    }

    private void OnDisable()
    {
        focusPanel.SetActive(false);
    }
}