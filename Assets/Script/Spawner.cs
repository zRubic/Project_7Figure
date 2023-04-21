using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy00 enemy;
    Wave currentWave;
    int currentWaveNum;
    int enemiesToSpawnCount;
    int enemiesAliveCount;
    float nextSpawnTiming;
    private void Start()
    {
        NextWave();
    }
    private void Update()
    {
        if (enemiesToSpawnCount>0 && Time.time > nextSpawnTiming)
        {
            enemiesToSpawnCount--;
            nextSpawnTiming = Time.time + currentWave.timeBetweenSpawns;

            Enemy00 spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            //其他类的某事件触发后，会发出广播；可以将本地方法加到此事件中，以在相应事件发生时执行；
            spawnedEnemy.OnDeathEvent += OnEnemyDeath;
        }

    }

    void OnEnemyDeath()
    {
        Debug.Log("Enemy died");
        enemiesAliveCount--;
        if (enemiesAliveCount <= 0)
        {
            NextWave();
        }
    }
    void NextWave()
    {
        currentWaveNum++;
        if (currentWaveNum<=waves.Length)
        {
            Debug.Log("Starting Wave:" + currentWaveNum);
            currentWave = waves[currentWaveNum - 1];
            enemiesToSpawnCount = currentWave.enemyCount;
            enemiesAliveCount = enemiesToSpawnCount;
        }
    }

    //序列化使类或结构体可在unity的inspector中展示，亦便于数据存储；
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
