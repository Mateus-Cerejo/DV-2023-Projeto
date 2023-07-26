using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    public List<ItemSO> unEquipedItems;
    public List<ItemSO> equipedArtifacts;
    public ItemSO equipedMeeleWeapon;
    public ItemSO equipedRangeWeapon;

    public int populationPerRound;    
    public int revivingSpeedPerc;
    public int curResearchPerc;
    public int researchPerRound;
    public int marketNumOfItems;
    public int factoryNumOfItems;
    public int factoryDiscountPerc;
    public int marketDiscountPerc;
    public int wood;
    public int stone;
    public int metal;
    public int pills;
    public int curPopulation;
    public int maxPopulation;
    public string itemsInMarket;
    public string itemsInFactory;
    public int hab1;
    public int hab2;
    public int hab3;
    public int hab4;
    public int market;
    public int hospital;
    public int lab;
    public int farm;
    public int factory;
    public int attackBonus;
    public int healthBonus;
    public int speedBonus;
    public int day;

    public SaveObject()
    {
        unEquipedItems = new List<ItemSO>();
        equipedArtifacts = new List<ItemSO>();
        equipedMeeleWeapon = null;
        equipedRangeWeapon = null;
        populationPerRound = 10;
        revivingSpeedPerc = 0;
        curResearchPerc = 0;
        researchPerRound = 3;
        marketNumOfItems = 0;
        factoryNumOfItems = 0;
        factoryDiscountPerc = 0;
        marketDiscountPerc = 0;
        wood = 10000;
        stone = 10000;
        metal = 5000;
        pills = 1000;
        curPopulation = 50;
        maxPopulation = 100;
        itemsInMarket = "";
        itemsInFactory = "";
        hab1 = 0;
        hab2 = 0;
        hab3 = 0;
        hab4 = 0;
        market = 0;
        hospital = 0;
        lab = 0;
        farm = 0;
        factory = 0;
        attackBonus = 1;
        healthBonus = 1;
        speedBonus = 1;
        day = 1;
    }

    public void Save()
    {
        unEquipedItems = Inventory.Instance.GetItemsUnequiped();
        equipedArtifacts = Inventory.Instance.GetArtifactsEquiped();
        equipedMeeleWeapon = Inventory.Instance.GetMeeleWeaponEquiped();
        equipedRangeWeapon = Inventory.Instance.GetRangeWeaponEquiped();

        populationPerRound = PlayerPrefs.GetInt("populationPerRound");
        revivingSpeedPerc = PlayerPrefs.GetInt("revivingSpeedPerc");
        curResearchPerc = PlayerPrefs.GetInt("curResearchPerc");
        researchPerRound = PlayerPrefs.GetInt("researchPerRound");
        marketNumOfItems = PlayerPrefs.GetInt("MarketNumOfItems");
        factoryNumOfItems = PlayerPrefs.GetInt("FactoryNumOfItems");
        factoryDiscountPerc = PlayerPrefs.GetInt("MarketDiscountPerc");
        marketDiscountPerc = PlayerPrefs.GetInt("FactoryDiscountPerc");
        wood = PlayerPrefs.GetInt("wood");
        stone = PlayerPrefs.GetInt("stone");
        metal = PlayerPrefs.GetInt("metal");
        pills = PlayerPrefs.GetInt("pills");
        curPopulation = PlayerPrefs.GetInt("curPopulation");
        maxPopulation = PlayerPrefs.GetInt("maxPopulation");
        itemsInMarket = PlayerPrefs.GetString("itemsInMarket");
        itemsInFactory = PlayerPrefs.GetString("itemsInFactory");
        hab1 = PlayerPrefs.GetInt("Hab 1");
        hab2 = PlayerPrefs.GetInt("Hab 2");
        hab3 = PlayerPrefs.GetInt("Hab 3");
        hab4 = PlayerPrefs.GetInt("Hab 4");
        market = PlayerPrefs.GetInt("Market");
        hospital = PlayerPrefs.GetInt("Factory");
        lab = PlayerPrefs.GetInt("Lab");
        farm = PlayerPrefs.GetInt("Farm");
        factory = PlayerPrefs.GetInt("Hospital");
        attackBonus = PlayerPrefs.GetInt("attackBonus");
        healthBonus = PlayerPrefs.GetInt("healthBonus");
        speedBonus = PlayerPrefs.GetInt("speedBonus");
        day = PlayerPrefs.GetInt("day");
    }

    public void Load()
    {
        Inventory.Instance.AddRangeItemsUnequiped(unEquipedItems);
        Inventory.Instance.SetArtifactsEquiped(equipedArtifacts);
        Inventory.Instance.SetMeeleWeaponEquiped(equipedMeeleWeapon);
        Inventory.Instance.SetRangeWeaponEquiped(equipedRangeWeapon);

        PlayerPrefs.SetInt("populationPerRound", populationPerRound);
        PlayerPrefs.SetInt("revivingSpeedPerc", revivingSpeedPerc);
        PlayerPrefs.SetInt("curResearchPerc", curResearchPerc);
        PlayerPrefs.SetInt("researchPerRound", researchPerRound);
        PlayerPrefs.SetInt("MarketNumOfItems", marketNumOfItems);
        PlayerPrefs.SetInt("FactoryNumOfItems", factoryNumOfItems);
        PlayerPrefs.SetInt("MarketDiscountPerc", marketDiscountPerc);
        PlayerPrefs.SetInt("FactoryDiscountPerc", factoryDiscountPerc);
        PlayerPrefs.SetInt("wood", wood);
        PlayerPrefs.SetInt("stone", stone);
        PlayerPrefs.SetInt("metal", metal);
        PlayerPrefs.SetInt("pills", pills);
        PlayerPrefs.SetInt("curPopulation", curPopulation);
        PlayerPrefs.SetInt("maxPopulation", maxPopulation);
        PlayerPrefs.SetString("itemsInMarket", itemsInMarket);
        PlayerPrefs.SetString("itemsInFactory", itemsInFactory);
        PlayerPrefs.SetInt("Hab 1", hab1);
        PlayerPrefs.SetInt("Hab 2", hab2);
        PlayerPrefs.SetInt("Hab 3", hab3);
        PlayerPrefs.SetInt("Hab 4", hab4);
        PlayerPrefs.SetInt("Market", market);
        PlayerPrefs.SetInt("Factory", factory);
        PlayerPrefs.SetInt("Lab", lab);
        PlayerPrefs.SetInt("Farm", farm);
        PlayerPrefs.SetInt("Hospital", hospital);
        PlayerPrefs.SetInt("attackBonus", attackBonus);
        PlayerPrefs.SetInt("healthBonus", healthBonus);
        PlayerPrefs.SetInt("speedBonus", speedBonus);
        PlayerPrefs.SetInt("day", day);
    }
}
