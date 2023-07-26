using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreview : MonoBehaviour
{
    [SerializeField] private GameObject detailedItem;
    [SerializeField] private GameObject detailedShopItem;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Button button;

    private ItemSO itemSO;
    private string type;
    private ShopItemDetailed shopItemDetailed;
    private ItemDetailed itemDetailed;

    public void SetUp(ItemSO itemSO, string type = "none")
    {
        this.type = type;
        if (type == "none")
        {
            button.enabled = false;
        }

        this.itemSO = itemSO;

        if (nameText != null) 
        { 
            nameText.text = (type == "none")? "" : itemSO.GetName();
        }
       
        sprite.GetComponent<Image>().sprite = itemSO.GetSprite();
    }

    public void OpenDetailedShopItem()
    {
        shopItemDetailed = Instantiate(detailedShopItem, GameObject.FindGameObjectWithTag("MainCanvas").transform).GetComponent<ShopItemDetailed>();
        shopItemDetailed.SetUp(itemSO, type);
    }

    public void OpenDetailedItem()
    {
        itemDetailed = Instantiate(detailedItem, GameObject.FindGameObjectWithTag("MainCanvas").transform).GetComponent<ItemDetailed>();
        itemDetailed.SetUp(itemSO);
    }

    public ItemSO GetItem()
    {
        return itemSO;
    }
}
