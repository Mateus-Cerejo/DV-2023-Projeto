using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGUIScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waveStateGUIs;

    public void displayWaveStateGUI(int waveState)
    {

        for (int i=0; i< waveStateGUIs.Length; i++)
        {
            Debug.Log("i value:" + i);
            Debug.Log("wave state value:" + waveState);
            //O GUI pertence ao estado da Onda?
            waveStateGUIs[i].gameObject.SetActive( i == waveState);
        }
            
    }

    //TBD
    public void updateDisplay(int enemiesLeft, int pills, int population)
    {
        
    }
}
