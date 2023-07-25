using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvents;


[System.Serializable] 
public class Wave
{
    [SerializeField] private Transform[] zombies;
    [SerializeField] private Transform[] bosses;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int spawnedEnemiesCount = 0;
    [SerializeField] private int maxEnemiesAllowed;
    [SerializeField] private int initEnemyAmount;
    [SerializeField] private int enemiesLeft;
    [SerializeField] private int nSpawnPerGroup = 5;
    [SerializeField] private int totalBosses;
    [SerializeField] private int bossesLeft;
    [SerializeField] private int bossSpawnDecision;
    // Start is called before the first frame update

    //NOT BEING USED
    public Wave(int waveNumber)
    {
        SetWaveStats(waveNumber);
    }


    public List<Transform> SpawnEnemies()
    {
        List<Transform> spawnedEnemies = new List<Transform>();

        for (int i = 0; i<nSpawnPerGroup; i++ ){
            if(enemyCount < maxEnemiesAllowed && enemyCount < enemiesLeft)
            {
                
                Transform enemy = ChooseEnemyPool();
                Debug.Log("Adding Enemy:" + enemy);
                spawnedEnemies.Add(enemy);
                enemyCount++;
                spawnedEnemiesCount++;
            }
           
        }
        return spawnedEnemies;
    }

    public void SetWaveStats(int waveNumber)
    {
        Debug.Log("SetStats of wave: " + waveNumber);
        waveNumber = (waveNumber == 0) ? 1 : waveNumber;
        initEnemyAmount = 10 + (waveNumber * 8)/2;
        enemiesLeft = initEnemyAmount;
        enemyCount = 0;
        maxEnemiesAllowed = 5 + waveNumber;
        nSpawnPerGroup = 2 + waveNumber/3;
        totalBosses = initEnemyAmount / 25;
        bossesLeft = totalBosses;
    }

    public void DecreaseEnemiesLeft(int enemiesCount)
    {
        if (enemyCount > 0)
        {
            enemyCount--;
            enemiesLeft -= enemiesCount;
        }
    }

    private Transform ChooseEnemyPool()
    {
        int enemyID;
        if (totalBosses > 0)
        {
            bossSpawnDecision = spawnedEnemiesCount % (initEnemyAmount / totalBosses);
            //int bossSpawnDecision = spa
            //Debug.Log("Boss spawn Decision: " + bossSpawnDecision);

            if (bossSpawnDecision == 0 && spawnedEnemiesCount != 0 || (totalBosses == 1 && ((float)spawnedEnemiesCount / initEnemyAmount == 0.5)))
            {
                enemyID = Random.Range(0, bosses.Length);
                return bosses[enemyID];
            }
        }
        
        enemyID = Random.Range(0, zombies.Length);
        return zombies[enemyID];
        
    }

    public bool TooFewEnemies()
    {     
        float enemyRatio = (float)enemyCount / maxEnemiesAllowed;
        return (enemyRatio < 0.5f);
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
