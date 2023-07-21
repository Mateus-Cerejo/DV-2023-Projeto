using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] 
public class Wave
{
    [SerializeField] private Transform[] enemies;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int maxEnemiesAllowed;
    [SerializeField] private int enemiesLeft;
    [SerializeField] private float timeBetweenGroupSpawns;
    [SerializeField] private int nSpawnPerGroup = 5;
    // Start is called before the first frame update
    
    //NOT BEING USED
    public Wave(int waveNumber)
    {
        SetWaveStats(waveNumber);
    }


    public List<Transform> SpawnEnemies()
    {
        List<Transform> spawnedEnemies = new List<Transform>();
        int enemyID;

        for (int i = 0; i<nSpawnPerGroup; i++ ){
            enemyID = Random.Range(0, enemies.Length);
            Debug.Log("Getting enemy:" + i);
            if(enemyCount < maxEnemiesAllowed && enemyCount < enemiesLeft)
            {
                Debug.Log("Adding Enemy:" + i);
                spawnedEnemies.Add(enemies[enemyID]);
                enemyCount++;
            }
           
        }
        return spawnedEnemies;
    }

    public void SetWaveStats(int waveNumber)
    {
        Debug.Log("SetStats of wave: " + waveNumber);
        waveNumber = (waveNumber == 0) ? 1 : waveNumber;
        enemiesLeft = 10 + (waveNumber * 5)/2;
        enemyCount = 2;
        maxEnemiesAllowed = 5 + waveNumber;
        timeBetweenGroupSpawns = 5 / waveNumber;
        nSpawnPerGroup = 5;
    }

    public void KillEnemy()
    {
        if (enemyCount > 0)
        {
            enemyCount--;
            enemiesLeft--;
        }
    }

    public bool moreEnemiesLeft()
    {
        return enemiesLeft > 0;
    }

    //NOT BEING USED
    public int EnemiesLeft
    {
        get => enemiesLeft;
        set => enemiesLeft = value;
    }
}
