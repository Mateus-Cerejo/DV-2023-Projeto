using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPreview : MonoBehaviour
{
    [SerializeField] private GameObject detailedShopItem;

    private ShopItemSO itemSO;
    private TextMeshProUGUI nameText;
    private GameObject sprite;

    public void SetUp(ShopItemSO itemSO)
    {
        this.itemSO = itemSO;
        nameText.text = itemSO.GetName();
        this.sprite.GetComponent<Image>().sprite = itemSO.GetSprite();
    }

    public void OpenDetailedShopItem()
    {
        detailedShopItem.SetActive(true);
    }

    private void OnMouseDown()
    {
        OpenDetailedShopItem();
    }
}
