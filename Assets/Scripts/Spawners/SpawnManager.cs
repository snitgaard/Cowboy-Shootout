using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int waveNumber = 1;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 2)
        {
            enemyCount++;
            waveNumber++;
            SpawnEnemyWave(waveNumber);
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
