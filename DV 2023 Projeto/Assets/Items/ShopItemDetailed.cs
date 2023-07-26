using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDetailed : MonoBehaviour
{
    [SerializeField] private GameObject spriteBG;
    [SerializeField] private GameObject sprite;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private TextMeshProUGUI woodCostText;
    [SerializeField] private TextMeshProUGUI stoneCostText;
    [SerializeField] private TextMeshProUGUI metalCostText;
    [SerializeField] private TextMeshProUGUI pillsCostText;

    [SerializeField] private TextMeshProUGUI detailsText;
    [SerializeField] private GameObject errorBuying;

    private ItemSO itemSO;
    private string type;
    private Color commun = new Color(188 / 255f, 188 / 255f, 188 / 255f);
    private Color rare = new Color(92 / 255f, 188/255f, 255/255f);
    private Color epic = new Color(161 / 255f, 92 / 255f, 255 / 255f);
    private Color legendary = new Color(255 / 255f, 223 / 255f, 92 / 255f);

    public void SetUp(ItemSO itemSO, string type)
    {
        this.type = type;
        this.itemSO = itemSO;
        nameText.text = this.itemSO.GetName();
        sprite.GetComponent<Image>().sprite = this.itemSO.GetSprite();

        switch (itemSO.GetRarity())
        {
            case Rarity.Common:
                {
                    spriteBG.GetComponent<Image>().color = commun;
                    nameText.color = commun;
                    nameText.text += "  *Commun*";
                }
                break;
            case Rarity.Rare:
                {
                    spriteBG.GetComponent<Image>().color = rare;
                    nameText.color = rare;
                    nameText.text += "  *Rare*";
                }
                break;
            case Rarity.Epic:
                {
                    spriteBG.GetComponent<Image>().color = epic;
                    nameText.color = epic;
                    nameText.text += "  *Epic*";
                }
                break;
            case Rarity.Legendary:
                {
                    spriteBG.GetComponent<Image>().color = legendary;
                    nameText.color = legendary;
                    nameText.text += "  *Legendary*";
                }
                break;
        }

        woodCostText.text = itemSO.GetPriceWithDiscount(type).GetWood() + "";
        stoneCostText.text = itemSO.GetPriceWithDiscount(type).GetStone() + "";
        metalCostText.text = itemSO.GetPriceWithDiscount(type).GetMetal() + "";
        pillsCostText.text = itemSO.GetPriceWithDiscount(type).GetPills() + "";

        detailsText.text = itemSO.GetDescription();
    }

    public void Buy()
    {
        if (MaterialsManager.Instance.Buy(itemSO.GetPriceWithDiscount(type)))
        {
            Destroy(gameObject);
            Inventory.Instance.AddItem(itemSO);
        }
        else
        {
            GameObject instance = Instantiate(errorBuying);
            instance.GetComponent<TextMeshProUGUI>().SetText("You don't have enough materials");
            instance.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
            Destroy(instance, 2);
        }
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
