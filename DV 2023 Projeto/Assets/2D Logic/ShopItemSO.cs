using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop Item")]
public class ShopItemSO : ScriptableObject
{ 
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private Rarity itemRarity;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private Materials itemPrice;

    public Sprite GetSprite() { return itemSprite; }
    public string GetName() { return itemName; }
    public string GetDescription() { return itemDescription; }
    public Materials GetPrice() { return itemPrice; }
    public Materials GetPriceWithDiscount(string type) 
    {
        float discount = 1 - PlayerPrefs.GetInt(type, 0) / 10f;
        return new Materials((int) (itemPrice.GetWood() * discount), (int) (itemPrice.GetStone() * discount), (int) (itemPrice.GetMetal() * discount), (int) (itemPrice.GetPills() * discount)); 
    }
    public Rarity GetRarity() { return itemRarity; }
}
