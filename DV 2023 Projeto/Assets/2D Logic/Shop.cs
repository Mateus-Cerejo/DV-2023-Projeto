using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private List<ShopItemSO> items;
    [SerializeField] private Transform grid;
    [SerializeField] private GameObject shopItem;
    [SerializeField] private GameObject rightSide;
    [SerializeField] private int numOfItemsToDisplay;
    
    private void Start()
    {
        
        foreach (ShopItemSO item in ChooseItemsRand())
        {
            shopItem.GetComponent<ShopItemPreview>().SetUp(item);
            Instantiate(shopItem, grid);
        }
    }

    private void OnEnable()
    {
        
        if (PlayerPrefs.GetInt(type, 0) == 0)
        {
            rightSide.SetActive(false);
        }
    }

    private void OnDisable()
    {
        rightSide.SetActive(true);
    }


    private List<ShopItemSO> ChooseItemsRand()
    {
        List<ShopItemSO> itemsToDisplay = new List<ShopItemSO>();
        List<int> usedIndexes = new List<int>();

        while (itemsToDisplay.Count < numOfItemsToDisplay)
        {
            int index = Random.Range(0, items.Count);
            if (!usedIndexes.Contains(index))
            {
                if (Random.Range(0, 101) <= (int) items[index].GetRarity())
                {
                    itemsToDisplay.Add(items[index]);
                    usedIndexes.Add(index);
                }
            }
        }

        return itemsToDisplay;
    }
}
