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


    //���л�ʹ���ṹ�����unity��inspector��չʾ����������ݴ洢��
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
