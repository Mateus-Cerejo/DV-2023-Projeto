using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private enum WaveState {START, ONGOING, END}

    [SerializeField] private Wave wave;
    [SerializeField] private int nWaveStates = System.Enum.GetValues(typeof(WaveState)).Length;

    [SerializeField] private WaveGUIScript waveGUIScript;


    [SerializeField] private GameObject[] spawners;
    [SerializeField] private int waveNumber;

    [SerializeField] private WaveState waveState;

    [SerializeField] private float waveStateIntermission;
    [SerializeField] private float curStateTime;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        wave.SetWaveStats(waveNumber);

        waveStateIntermission = 5f;
        waveState = WaveState.START;
        nWaveStates = System.Enum.GetValues(typeof(WaveState)).Length;

        waveGUIScript.displayWaveStateGUI((int)waveState);
        /*
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

        if(waveState == WaveState.ONGOING)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SpawnEnemyGroup();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                wave.SetWaveStats(waveNumber);
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Destroying Enemy");
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                wave.KillEnemy();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            //Next SpawnerState
            NextWaveState();

        }

    }

    private void SpawnEnemyGroup()
    {
        Debug.Log("Spawning");
        int spawnerID = Random.Range(0, spawners.Length);
        foreach (var enemy in wave.SpawnEnemies())
        {
            Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        }

    }

    private void NextWaveState()
    {
        float timeElapsed = Time.time - curStateTime;
        Debug.Log("Time Elapsed: " + timeElapsed);
        if (timeElapsed >= waveStateIntermission && waveState != WaveState.ONGOING)
        {
            //Debug.Log("Changing wave state");
            //Debug.Log("Currently in state: " + waveState);

            waveState += 1;
            if ((int)waveState == nWaveStates) waveState = 0;

            Debug.Log("Now in state: " + waveState);
            curStateTime = Time.time;

            
        }          
        else if((!wave.moreEnemiesLeft() && waveState == WaveState.ONGOING))
        {
            //Debug.Log("Changing wave state");
            //Debug.Log("Currently in state: " + waveState + "(" + (int)waveState +")");

            waveState += 1;
            if ((int)waveState == nWaveStates) waveState = 0;

            Debug.Log("Now in state: " + waveState);
            curStateTime = Time.time;

            
        }

        waveGUIScript.displayWaveStateGUI((int)waveState);
    }
}
