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
        //SpawnEnemies();
    }
    private void SpawnEnemy()
    {
        Vector2 spawnPosition = spawnPoint.position + (Vector3)Random.insideUnitCircle * spawnRadius;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemies.Add(newEnemy);
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.enemyCounter++;
    }

    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount;i++)
        {
             SpawnEnemy();
        }
    }

    public void DestroyAllOfEnemies(){
    GameManagerScript _managerInstance = GameManagerScript.Instance;
    foreach (GameObject enemy in enemies)
    {
        Destroy(enemy);
        _managerInstance.enemyCounter--;
    }
    enemies.Clear();
    }
}
