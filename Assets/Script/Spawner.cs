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
            //�������ĳ�¼������󣬻ᷢ���㲥�����Խ����ط����ӵ����¼��У�������Ӧ�¼�����ʱִ�У�
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

    //���л�ʹ���ṹ�����unity��inspector��չʾ����������ݴ洢��
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
