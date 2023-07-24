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
    private string type;
    private ShopItemDetailed itemDetailed;

    public void SetUp(ShopItemSO itemSO, string type)
    {
        this.type = type;
        this.itemSO = itemSO;
        nameText.text = itemSO.GetName();
        sprite.GetComponent<Image>().sprite = itemSO.GetSprite();
        
    }

    public void OpenDetailedShopItem()
    {
        itemDetailed = Instantiate(detailedShopItem, GameObject.FindGameObjectWithTag("MainCanvas").transform).GetComponent<ShopItemDetailed>();
        itemDetailed.SetUp(itemSO, type);
    }
}
