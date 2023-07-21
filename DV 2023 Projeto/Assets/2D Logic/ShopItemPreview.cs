using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPreview : MonoBehaviour
{
    [SerializeField] private GameObject detailedShopItem;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject sprite;

    private ShopItemSO itemSO;

    public void SetUp(ShopItemSO itemSO)
    {
        this.itemSO = itemSO;
        nameText.text = itemSO.GetName();
        sprite.GetComponent<Image>().sprite = itemSO.GetSprite();
    }

    public void OpenDetailedShopItem()
    {
        detailedShopItem.GetComponent<ShopItemDetailed>().SetUp(itemSO);
        detailedShopItem.SetActive(true);
    }

    private void OnMouseDown()
    {
        OpenDetailedShopItem();
    }
}
