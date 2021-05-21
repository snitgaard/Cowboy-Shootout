using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveNumber = 1;
    public int enemyCount;
    public bool startSpawn;
    private float spawnRange = 80;

    public void startEnemySpawn() 
    {
        startSpawn = true;
    }
    void Update()
    {
        if (startSpawn == true)
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                SpawnEnemyWave(waveNumber);
                waveNumber++;
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPositions(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPositions() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
