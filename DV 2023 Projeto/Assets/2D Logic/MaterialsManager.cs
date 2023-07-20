using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodLabel;
    [SerializeField] private TextMeshProUGUI stoneLabel;
    [SerializeField] private TextMeshProUGUI metalLabel;

    private Materials materials;

    private void Start()
    {
        int initialWood = 10000;
        int initialStone = 10000;
        int initialMetal = 10000;

        materials = new Materials(initialWood, initialStone, initialMetal);

        materials.SetWood(PlayerPrefs.GetInt("wood", initialWood));
        materials.SetStone(PlayerPrefs.GetInt("stone", initialStone));
        materials.SetMetal(PlayerPrefs.GetInt("metal", initialMetal));

        woodLabel.SetText("" + materials.GetWood());
        stoneLabel.SetText("" + materials.GetStone());
        metalLabel.SetText("" + materials.GetMetal());
    }

    public bool Buy(Materials price)
    {
        if (price.GetWood() > materials.GetWood() || price.GetStone() > materials.GetStone() || price.GetMetal() > materials.GetMetal())
        {
            return false;
        }
        AddOrSubWood(-price.GetWood());
        AddOrSubStone(-price.GetStone());
        AddOrSubMetal(-price.GetMetal());

        return true;
    }

    private void AddOrSubWood(int amount)
    {
        materials.SetWood(amount + materials.GetWood());
        woodLabel.SetText("" + materials.GetWood());

        PlayerPrefs.SetInt("wood", materials.GetWood());
    }

    private void AddOrSubStone(int amount)
    {
        materials.SetStone(amount + materials.GetStone());
        stoneLabel.SetText("" + materials.GetStone());

        PlayerPrefs.SetInt("stone", materials.GetStone());
    }

    private void AddOrSubMetal(int amount)
    {
        materials.SetMetal(amount + materials.GetMetal());
        metalLabel.SetText("" + materials.GetMetal());

        PlayerPrefs.SetInt("metal", materials.GetMetal());
    }
}
