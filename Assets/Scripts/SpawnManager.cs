using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnPosY = 1.6f;
    private float spawnPosZ = 32.0f;
    private float startDelay = 2f;
    private float spawnInterval = 9f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTopLeftEnemies", startDelay, spawnInterval);
        InvokeRepeating("SpawnTopRightEnemies", startDelay, spawnInterval);
        InvokeRepeating("SpawnBottomLeftEnemies", startDelay, spawnInterval);
        InvokeRepeating("SpawnBottomRightEnemies", startDelay, spawnInterval);
    }

    private void SpawnTopLeftEnemies()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10.0f, -2.0f), spawnPosY, spawnPosZ);
        if (!GameManager.isGameOver)
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    private void SpawnTopRightEnemies()
    {
        Vector3 spawnPos = new Vector3(Random.Range(31.0f, 41.0f), spawnPosY, spawnPosZ);
        if (!GameManager.isGameOver)
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    private void SpawnBottomLeftEnemies()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10.0f, -2.0f), spawnPosY, 7);
        if (!GameManager.isGameOver)
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    private void SpawnBottomRightEnemies()
    {
        Vector3 spawnPos = new Vector3(Random.Range(31.0f, 41.0f), spawnPosY, 7);
        if (!GameManager.isGameOver)
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
