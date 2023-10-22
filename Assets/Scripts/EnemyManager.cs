using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Dictionary<Vector2, GameObject> instantiatedEnemies = new Dictionary<Vector2, GameObject>();

    public GameObject spawnContainer;
    public GameObject enemyPrefab;
    private List<Vector3> spawnPoints = new List<Vector3>();
    public int spawnQuantity = 10;
    public float spawnInterval = 2.0f;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private int spawnedCount = 0;
    public static EnemyManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        // Collect spawn points from child objects.
        foreach (Transform child in spawnContainer.transform)
        {
            spawnPoints.Add(child.position);
        }

        // Start spawning enemies.
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnedCount < spawnQuantity)
        {
            Vector2 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // Create an enemy at the random spawn point.
            GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
            spawnedCount++;

            if (spawnedCount >= spawnQuantity)
            {
                CancelInvoke("SpawnEnemy"); // Stop spawning when the desired quantity is reached.
            }
        }
    }
}
