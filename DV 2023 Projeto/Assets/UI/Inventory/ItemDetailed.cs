using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailed : MonoBehaviour
{
    [SerializeField] private GameObject spriteBG;
    [SerializeField] private GameObject sprite;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private TextMeshProUGUI detailsText;

    private ItemSO itemSO;

    private Color commun = new Color(188 / 255f, 188 / 255f, 188 / 255f);
    private Color rare = new Color(92 / 255f, 188 / 255f, 255 / 255f);
    private Color epic = new Color(161 / 255f, 92 / 255f, 255 / 255f);
    private Color legendary = new Color(255 / 255f, 223 / 255f, 92 / 255f);

    public void SetUp(ItemSO itemSO)
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

        detailsText.text = itemSO.GetDescription();
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
