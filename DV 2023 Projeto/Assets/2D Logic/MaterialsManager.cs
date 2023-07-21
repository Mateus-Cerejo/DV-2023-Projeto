using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MaterialsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodLabel;
    [SerializeField] private TextMeshProUGUI stoneLabel;
    [SerializeField] private TextMeshProUGUI metalLabel;
    [SerializeField] private TextMeshProUGUI pillsLabel;

    private Materials materials;

    private void Start()
    {
        int initialWood = 10000;
        int initialStone = 10000;
        int initialMetal = 10000;
        int initialPills = 10000;

        materials = new Materials(initialWood, initialStone, initialMetal, initialPills);

        materials.SetWood(PlayerPrefs.GetInt("wood", initialWood));
        materials.SetStone(PlayerPrefs.GetInt("stone", initialStone));
        materials.SetMetal(PlayerPrefs.GetInt("metal", initialMetal));
        materials.SetPills(PlayerPrefs.GetInt("pills", initialPills));

        woodLabel.SetText("" + materials.GetWood());
        stoneLabel.SetText("" + materials.GetStone());
        metalLabel.SetText("" + materials.GetMetal());
        pillsLabel.SetText("" + materials.GetPills());
    }

    public bool Buy(Materials price)
    {
        if (price.GetWood() > materials.GetWood() || price.GetStone() > materials.GetStone() || price.GetMetal() > materials.GetMetal() || price.GetPills() > materials.GetPills())
        {
            return false;
        }

        AddOrSubWood(-price.GetWood());
        AddOrSubStone(-price.GetStone());
        AddOrSubMetal(-price.GetMetal());
        AddOrSubPills(-price.GetPills());

        return true;
    }

    public void AddOrSubWood(int amount)
    {
        materials.SetWood(amount + materials.GetWood());
        woodLabel.SetText("" + materials.GetWood());

        PlayerPrefs.SetInt("wood", materials.GetWood());
    }

    public void AddOrSubStone(int amount)
    {
        materials.SetStone(amount + materials.GetStone());
        stoneLabel.SetText("" + materials.GetStone());

        PlayerPrefs.SetInt("stone", materials.GetStone());
    }

    public void AddOrSubMetal(int amount)
    {
        materials.SetMetal(amount + materials.GetMetal());
        metalLabel.SetText("" + materials.GetMetal());

        PlayerPrefs.SetInt("metal", materials.GetMetal());
    }

    public void AddOrSubPills(int amount)
    {
        materials.SetPills(amount + materials.GetPills());
        pillsLabel.SetText("" + materials.GetPills());

        PlayerPrefs.SetInt("pills", materials.GetPills());
    }
}
