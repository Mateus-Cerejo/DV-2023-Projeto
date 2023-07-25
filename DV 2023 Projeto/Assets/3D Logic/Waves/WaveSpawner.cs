using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private enum WaveState {START, ONGOING, END}

    [SerializeField] private Wave wave;
    [SerializeField] private int nWaveStates = System.Enum.GetValues(typeof(WaveState)).Length;

    [SerializeField] private WaveGUIScript waveGUIScript;

    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private PlayerLoot playerLoot;


    [SerializeField] private GameObject[] spawners;
    [SerializeField] private int waveNumber;

    [SerializeField] private WaveState waveState;

    [SerializeField] private float waveStateIntermission;
    [SerializeField] private float curStateTime;
    [SerializeField] private bool isWaveOver;

    [SerializeField] private float enemySpawnTimeInterval;
    [SerializeField] private float curEnemySpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        wave.SetWaveStats(waveNumber);

        enemySpawnTimeInterval = 5f - ((float)waveNumber * 0.1f); 

        waveStateIntermission = 5f;
        waveState = WaveState.START;
        nWaveStates = System.Enum.GetValues(typeof(WaveState)).Length;

        waveGUIScript.DisplayWaveStateGUI((int)waveState);
        waveGUIScript.CurrentDayDisplay(waveNumber);
        waveGUIScript.UpdateZombiesDisplay(wave.EnemiesLeft, playerLoot.Pills);

        gameEvents.OnWaveStateChanged += OnWaveStateChanged;
        gameEvents.OnEnemyDeath += HandleEnemyDeath;

        StartCoroutine("waveStateChange", waveStateIntermission);
        StartCoroutine("EnemySpawnBehaviour", enemySpawnTimeInterval);
        /*
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject;
        }
        */
    }

    private IEnumerator waveStateChange(float intermission)
    {
        while (true)
        {
            yield return new WaitForSeconds(intermission);
            Debug.Log("In Enum");

            float timeElapsed = Time.time - curEnemySpawnTime;
            if (timeElapsed >= waveStateIntermission && waveState != WaveState.ONGOING)
            {            
                if (isWaveOver)
                {
                    SceneManager.LoadScene(sceneName: "Main Scene");
                }
                //Debug.Log("Changing wave state");
                //Debug.Log("Currently in state: " + waveState);

                waveState += 1;
                if ((int)waveState == nWaveStates) waveState = 0;
                gameEvents.InvokeWaveStateChanged((int)waveState);

                Debug.Log("Now in state: " + waveState);
                curStateTime = Time.time;


            }
        }

    }

    private IEnumerator EnemySpawnBehaviour(float spawnTimer)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            Debug.Log("In Enum Spawn Enemy");

            float timeElapsed = Time.time - curEnemySpawnTime;
            if (timeElapsed >= enemySpawnTimeInterval  && waveState == WaveState.ONGOING)
            {
                SpawnEnemyGroup();
                curEnemySpawnTime = Time.time;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (waveState == WaveState.ONGOING)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SpawnEnemyGroup();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                wave.SetWaveStats(waveNumber);
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Destroying Enemy");
                GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
                if(enemy.GetComponent<ZombieStats>() == null)
                {
                    enemy.GetComponent<BruteStats>().Die();
                }
                else{
                    enemy.GetComponent<ZombieStats>().Die();
                }
                
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
        if (waveState != WaveState.ONGOING)
        {
            if (isWaveOver)
            {
                SceneManager.LoadScene(sceneName: "Main Scene");
                return;
            }
            //Debug.Log("Changing wave state");
            //Debug.Log("Currently in state: " + waveState);

            waveState += 1;
            if ((int)waveState == nWaveStates) waveState = 0;

            Debug.Log("Now in state: " + waveState);
            curStateTime = Time.time;

            
        }          
        else if( waveState == WaveState.ONGOING)
        {
            //Debug.Log("Changing wave state");
            //Debug.Log("Currently in state: " + waveState + "(" + (int)waveState +")");

            waveState += 1;
            if ((int)waveState == nWaveStates) waveState = 0;

            Debug.Log("Now in state: " + waveState);
            curStateTime = Time.time;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                Destroy(enemy);
            
            isWaveOver = true;


        }
        
        waveGUIScript.DisplayWaveStateGUI((int)waveState);
    }

    private void HandleEnemyDeath(int enemyCount)
    {
        
        if (wave.TooFewEnemies())
        {
            SpawnEnemyGroup();
            curEnemySpawnTime = Time.time;
        }
        
        wave.DecreaseEnemiesLeft(enemyCount);
        playerLoot.Pills += 1 + (waveNumber/2);
        // Update pills count in waveGUIScript
        waveGUIScript.UpdateZombiesDisplay( wave.EnemiesLeft ,playerLoot.Pills);

        if (waveState == WaveState.ONGOING && !wave.moreEnemiesLeft())
        {
            isWaveOver = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject e in enemies)
                Destroy(e);

            waveState += 1;
            gameEvents.InvokeWaveStateChanged((int)waveState); // Notify listeners of wave state change
            curStateTime = Time.time;
        }
    }

    private void OnWaveStateChanged(int waveState)
    {
        waveGUIScript.DisplayWaveStateGUI(waveState);
    }
}
