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
    [SerializeField] private int itemPrice;

    public Sprite GetSprite() { return itemSprite; }
    public string GetName() { return itemName; }
    public string GetDescription() { return itemDescription; }
    public int GetPrice() { return itemPrice; }
    public Rarity GetRarity() { return itemRarity; }
}
