using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnRadius = 5.0f;
    public int maxEnemies = 3;
    private List<GameObject> enemies = new List<GameObject>();


    private void Start()
    {
        SpawnEnemies();
    }
    private void SpawnEnemy()
    {
        Vector2 spawnPosition = spawnPoint.position + (Vector3)Random.insideUnitCircle * spawnRadius;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemies.Add(newEnemy);
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < maxEnemies;i++)
        {
             SpawnEnemy();
        }
    }
}
