using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private List<ItemSO> items;
    [SerializeField] private Transform grid;
    [SerializeField] private GameObject shopItem;
    [SerializeField] private GameObject rightSide;
    [SerializeField] private int numOfItemsToDisplay;

    private List<GameObject> previews;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => SaveManager.Instance.ready);

        numOfItemsToDisplay = PlayerPrefs.GetInt(type + "NumOfItems", 3);
        previews = new List<GameObject>();

        if (PlayerPrefs.GetInt(type, 0) != 0)
        {
            FillShop();
        }
    }

    private void OnEnable()
    {
        rightSide.SetActive(!(PlayerPrefs.GetInt(type, 0) == 0));
    }

    private void ClearShop() {
        PlayerPrefs.SetString("itemsIn" + type, "");
        foreach (GameObject preview in previews)
        {
            Destroy(preview);
        }
    }

    public void RefreshShop()
    {
        numOfItemsToDisplay = PlayerPrefs.GetInt(type + "NumOfItems");

        ClearShop();

        FillShop();
    }

    private void FillShop()
    {
        if (PlayerPrefs.GetString("itemsIn" + type, "").Equals(""))
        {
            foreach (ItemSO item in ChooseItemsRand())
            {
                GameObject preview = Instantiate(shopItem, grid);
                preview.GetComponent<ItemPreview>().SetUp(item, type);
                previews.Add(preview);
            }
        }
        else
        {
            string[] itemsInShopString = PlayerPrefs.GetString("itemsIn" + type).Split(" ");
            foreach (string itemIndex in itemsInShopString)
            {
                Debug.Log(int.Parse(itemIndex));
                GameObject preview = Instantiate(shopItem, grid);
                preview.GetComponent<ItemPreview>().SetUp(items[int.Parse(itemIndex)], type);
                previews.Add(preview);
            }
        }
    }

    private List<ItemSO> ChooseItemsRand()
    {
        List<ItemSO> itemsToDisplay = new List<ItemSO>();
        List<int> usedIndexes = new List<int>();
        string itemsIndexesString = "";

        while (itemsToDisplay.Count < numOfItemsToDisplay)
        {
            int index = Random.Range(0, items.Count);
            if (!usedIndexes.Contains(index))
            {
                if (Random.Range(0, 101) <= (int)items[index].GetRarity())
                {
                    itemsToDisplay.Add(items[index]);
                    usedIndexes.Add(index);
                    itemsIndexesString += (itemsIndexesString.Equals("")) ? "" + index : " " + index;
                }
            }
        }

        PlayerPrefs.SetString("itemsIn" + type, itemsIndexesString);

        return itemsToDisplay;
    }
}
