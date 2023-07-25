using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveGUIScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waveStateGUIs;
    private int currentWaveState;

    [SerializeField] private TextMeshProUGUI zombiesCountText;
    [SerializeField] private TextMeshProUGUI pillsCountText;
    [SerializeField] private TextMeshProUGUI populationCountText;

    [SerializeField] private TextMeshProUGUI dayNumberText;

    

    private void Start()
    {
        currentWaveState = 0; // Set the initial wave state (you can change this as needed)
        DisplayWaveStateGUI(currentWaveState);
    }

    public void DisplayWaveStateGUI(int waveState)
    {
        for (int i = 0; i < waveStateGUIs.Length; i++)
        {
            waveStateGUIs[i].SetActive(i == waveState);
        }
    }

    public void CurrentDayDisplay(int wave)
    {
        dayNumberText.text = "Starting Day " + wave;
    }


    public void UpdateZombiesDisplay(int enemiesLeft, int pills)
    {
        zombiesCountText.text = enemiesLeft.ToString();
        pillsCountText.text = pills.ToString();
        populationCountText.text = PlayerPrefs.GetInt("curPopulation").ToString();
    }

    public void OnWaveStateChanged(int newWaveState)
    {
        currentWaveState = newWaveState;
        DisplayWaveStateGUI(currentWaveState);
    }
}
