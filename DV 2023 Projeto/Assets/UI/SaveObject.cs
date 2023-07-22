using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    public int populationPerRound;
    public int revivingSpeedPerc;
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

    public SaveObject()
    {
        populationPerRound = 10;
        revivingSpeedPerc = 0;
        researchPerRound = 3;
        marketNumOfItems = 0;
        factoryNumOfItems = 0;
        factoryDiscountPerc = 0;
        marketDiscountPerc = 0;
        wood = 100;
        stone = 100;
        metal = 50;
        pills = 10;
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
    }

    public void Save()
    {
        populationPerRound = PlayerPrefs.GetInt("populationPerRound");
        revivingSpeedPerc = PlayerPrefs.GetInt("revivingSpeedPerc");
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
    }

    public void Load()
    {
        PlayerPrefs.SetInt("populationPerRound", populationPerRound);
        PlayerPrefs.SetInt("revivingSpeedPerc", revivingSpeedPerc);
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
    }
}
