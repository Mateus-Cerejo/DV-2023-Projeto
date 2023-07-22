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
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI detailsText;
    [SerializeField] private GameObject errorBuying;

    private ShopItemSO itemSO;
    private Color commun = new Color(188 / 255f, 188 / 255f, 188 / 255f);
    private Color rare = new Color(92 / 255f, 188/255f, 255/255f);
    private Color epic = new Color(161 / 255f, 92 / 255f, 255 / 255f);
    private Color legendary = new Color(255 / 255f, 223 / 255f, 92 / 255f);
    public void SetUp(ShopItemSO itemSO)
    {
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

        costText.text = itemSO.GetPrice() + "\nEach";

        detailsText.text = itemSO.GetDescription();
    }

    public void Buy()
    {
        if (MaterialsManager.Instance.Buy(new Materials(0, 0, 0, itemSO.GetPrice())))
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject instance = Instantiate(errorBuying);
            instance.GetComponent<TextMeshProUGUI>().SetText("You don't have enough pills");
            instance.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
            Destroy(instance, 2);
        }
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
