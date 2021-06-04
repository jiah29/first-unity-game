using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int waveNumber = 1;
    private int enemyCount;
    private float spawnX = 11.5f;
    private float spawnZ = 4.5f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnLocationX = Random.Range(-spawnX, spawnX);
        float spawnLocationZ = Random.Range(-spawnZ, spawnZ);
        Vector3 randomPos = new Vector3(spawnLocationX, 0, spawnLocationZ);
        return randomPos;
    }
}
