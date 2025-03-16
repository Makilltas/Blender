using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject emeny = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        Health enemyScript = emeny.GetComponent<Health>();

        
    }
}