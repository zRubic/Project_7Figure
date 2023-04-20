using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy00 enemy;
    int enemiesToSpawn;
    float nextSpawnTiming;
    private void Update()
    {
        
    }


    //序列化使类或结构体可在unity的inspector中展示，亦便于数据存储；
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
