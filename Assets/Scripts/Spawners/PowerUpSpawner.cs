﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUp;
    private float spawnRange = 80;
    public int powerUpCount;

    // Update is called once per frame
    void Update()
    {
        powerUpCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        if (powerUpCount == 0)
        {
            Debug.Log("Spawned new PowerUp");
            Instantiate(powerUp, GenerateSpawnPositions(), powerUp.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPositions()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);
        return randomPos;
    }

    public void spawnPowerUp() 
    {
        Instantiate(powerUp, GenerateSpawnPositions(), powerUp.transform.rotation);
    }
}
