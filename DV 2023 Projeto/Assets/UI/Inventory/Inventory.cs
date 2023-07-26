using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private RectTransform meeleSlot;
    [SerializeField] private RectTransform rangeSlot;
    [SerializeField] private List<RectTransform> artifactSlots;

    [SerializeField] private WeaponManagerIndex weaponManager;
    [SerializeField] private ArtifactBackPack artifactBackPack;
    [SerializeField] private Transform inventoryGrid;
    [SerializeField] private GameObject itemPreview;

    private List<ItemSO> itemsUnequiped;
    private List<ItemSO> artifactsEquiped;
    private ItemSO meeleWeaponEquiped;
    private ItemSO rangeWeaponEquiped;

    private List<ItemPreview> displayingUnequiped;
    private List<ItemPreview> displayingArtifacts;
    private ItemPreview displayingMeele;
    private ItemPreview displayingRange;

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        itemsUnequiped = new List<ItemSO>();
        artifactsEquiped = new List<ItemSO>();
        meeleWeaponEquiped = null;
        rangeWeaponEquiped = null;
        displayingUnequiped = new List<ItemPreview>();
        displayingArtifacts = new List<ItemPreview>();
        displayingMeele = null;
        displayingRange = null;
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        foreach (ItemSO item in itemsUnequiped)
        {
            ItemPreview newPreview = Instantiate(itemPreview, inventoryGrid).GetComponent<ItemPreview>();
            newPreview.SetUp(item);
            displayingUnequiped.Add(newPreview);
        }

        int artifactSlotCount = 0;
        foreach (ItemSO item in artifactsEquiped)
        {
            ItemPreview newPreview = Instantiate(itemPreview, inventoryGrid).GetComponent<ItemPreview>();
            newPreview.transform.SetParent(artifactSlots[artifactSlotCount]);
            newPreview.SetUp(item);
            newPreview.GetComponent<RectTransform>().position = artifactSlots[artifactSlotCount++].GetComponent<RectTransform>().position;
            displayingArtifacts.Add(newPreview);
        }

        if (meeleWeaponEquiped != null)
        {
            displayingMeele = Instantiate(itemPreview, inventoryGrid).GetComponent<ItemPreview>();
            displayingMeele.transform.SetParent(meeleSlot);
            displayingMeele.SetUp(meeleWeaponEquiped);
            displayingMeele.GetComponent<RectTransform>().position = meeleSlot.GetComponent<RectTransform>().position;
        }

        if (rangeWeaponEquiped != null)
        {
            displayingRange = Instantiate(itemPreview, inventoryGrid).GetComponent<ItemPreview>();
            displayingRange.transform.SetParent(rangeSlot);
            displayingRange.SetUp(rangeWeaponEquiped);
            displayingRange.GetComponent<RectTransform>().position = rangeSlot.GetComponent<RectTransform>().position;
        }
    }

    private void OnDisable()
    {
        foreach (ItemPreview itemPrev in displayingUnequiped)
        {
            if (itemPrev != null)
            {
                Destroy(itemPrev.gameObject);
            }
        }

        foreach (ItemPreview itemPrev in displayingArtifacts)
        {
            if (itemPrev != null)
            {
                Destroy(itemPrev.gameObject);
            }
        }

        if (displayingMeele != null)
        {
            Destroy(displayingMeele.gameObject);
        }

        if (displayingRange != null)
        {
            Destroy(displayingRange.gameObject);
        }
    }

    public void RemoveFromUnequiped(ItemSO item)
    {
        itemsUnequiped.Remove(item);
    }

    public void AddItem(ItemSO item)
    {
        itemsUnequiped.Add(item);
    }

    public bool EquipeMeeleWeapon(ItemSO item)
    {
        if (item.GetItemType().Equals(ItemType.MeeleWeapon))
        {
            meeleWeaponEquiped = item;

            switch (item.GetName())
            {
                case "BaseballBat":
                    {
                        weaponManager.currentMeleeIndex = 0;
                    }
                    break;
                case "Chainsaw":
                    {
                        weaponManager.currentMeleeIndex = 1;
                    }break;
            }
            return true;
        }
        return false;
    }

    public bool EquipeRangeWeapon(ItemSO item)
    {
        if (item.GetItemType().Equals(ItemType.RangeWeapon))
        {
            rangeWeaponEquiped = item;

            switch (item.GetName())
            {
                case "Pistol":
                    {
                        weaponManager.currentRangedIndex = 0;
                    }
                    break;
                case "SMG":
                    {
                        weaponManager.currentRangedIndex = 1;
                    }
                    break;
                case "AK":
                    {
                        weaponManager.currentRangedIndex = 2;
                    }
                    break;
                case "Shotgun":
                    {
                        weaponManager.currentRangedIndex = 3;
                    }
                    break;
                case "Sniper":
                    {
                        weaponManager.currentRangedIndex = 4;
                    }
                    break;
                case "Admin Gun":
                    {
                        weaponManager.currentRangedIndex = 5;
                    }
                    break;
            }
            return true;
        }
        return false;
    }

    public bool EquipeArtifact(ItemSO item)
    {
        if (item.GetItemType().Equals(ItemType.Artifact))
        {
            artifactsEquiped.Add(item);

            switch (item.GetName())
            {
                case "Speed":
                    {
                        artifactBackPack.speedArtifactQuantityEquiped += 1;
                    }
                    break;
                case "Power":
                    {
                        artifactBackPack.powerArtifactQuantityEquiped += 1;
                    }
                    break;
                case "Looter":
                    {
                        artifactBackPack.looterArtifactQuantityEquiped += 1;
                    }
                    break;
                case "Life":
                    {
                        artifactBackPack.lifeArtifactQuantityEquiped += 1;
                    }
                    break;
                case "Ice Aura":
                    {
                        artifactBackPack.iceAuraArtifactQuantityEquiped += 1;
                    }
                    break;
                case "All In One":
                    {
                        artifactBackPack.allInOneArtifactQuantityEquiped += 1;
                    }
                    break;
            }
            return true;
        }
        return false;
    }

    public bool UnEquipeItem(ItemSO item)
    {
        switch (item.GetItemType())
        {
            case ItemType.MeeleWeapon:
                {
                    if (meeleWeaponEquiped == item)
                    {
                        meeleWeaponEquiped = null;
                        weaponManager.currentMeleeIndex = 0;
                        return true;
                    }
                }
                break;
            case ItemType.RangeWeapon:
                {
                    if (rangeWeaponEquiped == item)
                    {
                        rangeWeaponEquiped = null;
                        weaponManager.currentRangedIndex = 0;
                        return true;
                    }
                }
                break;
            case ItemType.Artifact:
                {
                    UnEquipeArtifact(item);
                    return true;
                }
        }
        return false;
    }

    private void UnEquipeArtifact(ItemSO item)
    {
        for (int i = 0; i < artifactsEquiped.Count; i++)
        {
            if (artifactsEquiped[i] == item) { 
                artifactsEquiped.Remove(item);
                switch (item.GetName())
                {
                    case "Speed":
                        {
                            artifactBackPack.speedArtifactQuantityEquiped -= 1;
                        }
                        break;
                    case "Power":
                        {
                            artifactBackPack.powerArtifactQuantityEquiped -= 1;
                        }
                        break;
                    case "Looter":
                        {
                            artifactBackPack.looterArtifactQuantityEquiped -= 1;
                        }
                        break;
                    case "Life":
                        {
                            artifactBackPack.lifeArtifactQuantityEquiped -= 1;
                        }
                        break;
                    case "Ice Aura":
                        {
                            artifactBackPack.iceAuraArtifactQuantityEquiped -= 1;
                        }
                        break;
                    case "All In One":
                        {
                            artifactBackPack.allInOneArtifactQuantityEquiped -= 1;
                        }
                        break;
                }
                break;
            }
        }
    }

    public List<ItemSO> GetItemsUnequiped() { return itemsUnequiped; }
    public List<ItemSO> GetArtifactsEquiped() { return artifactsEquiped; }
    public ItemSO GetMeeleWeaponEquiped() { return meeleWeaponEquiped; }
    public ItemSO GetRangeWeaponEquiped() { return rangeWeaponEquiped; }

    public void SetItemsUnequiped(List<ItemSO> itemList) { itemsUnequiped = itemList; }
    public void SetArtifactsEquiped(List<ItemSO> itemList) { artifactsEquiped = itemList; }
    public void SetMeeleWeaponEquiped(ItemSO item) { meeleWeaponEquiped = item; }
    public void SetRangeWeaponEquiped(ItemSO item) { rangeWeaponEquiped = item; }


    public void DebugTHIS()
    {
        Debug.Log("Unequiped: " + itemsUnequiped.Count);
        Debug.Log("Meele: " + meeleWeaponEquiped);
        Debug.Log("Range: " + rangeWeaponEquiped);
        Debug.Log("Artifacts: " + artifactsEquiped.Count);
    }
}
