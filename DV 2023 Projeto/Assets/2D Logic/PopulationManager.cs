using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI populationText;
    [SerializeField] private int maxPopulation = 100;

    private int curPopulation;

    public static PopulationManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        curPopulation = PlayerPrefs.GetInt("population", 50);
        UpdateText();
    }

    private void AddOrSubPopulation(int amount)
    {
        curPopulation = Mathf.Clamp(curPopulation + amount, 0, maxPopulation);
        UpdateText();

        PlayerPrefs.SetInt("population", curPopulation);
    }

    private void UpdateText()
    {
        populationText.SetText(curPopulation + " / " + maxPopulation);
    }
}
