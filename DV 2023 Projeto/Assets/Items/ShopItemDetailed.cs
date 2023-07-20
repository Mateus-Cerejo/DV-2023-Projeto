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
    [SerializeField] private TextMeshProUGUI detailsText;

    private ShopItemSO itemSO;

    public void SetUp(ShopItemSO itemSO)
    {
        this.itemSO = itemSO;
        nameText.text = itemSO.GetName();
        this.sprite.GetComponent<Image>().sprite = itemSO.GetSprite();

        switch (itemSO.GetRarity())
        {
            case Rarity.Common:
                {
                    spriteBG.GetComponent<Image>().color = new Color(188, 188, 188);
                }
                break;
            case Rarity.Rare:
                {
                    spriteBG.GetComponent<Image>().color = new Color(92, 188, 255);

                }
                break;
            case Rarity.Epic:
                {
                    spriteBG.GetComponent<Image>().color = new Color(161, 92, 255);
                }
                break;
            case Rarity.Legendary:
                {
                    spriteBG.GetComponent<Image>().color = new Color(255, 223, 92);
                }
                break;
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
