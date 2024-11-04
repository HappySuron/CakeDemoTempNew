using System.Collections;
using UnityEngine;

public class EnemyEncounterRoomWater : RoomVirtual
{
    public int enemiesToSpawn = 1;
    public GameObject spawner;
    public GameObject bucketOfWaterPrefab;
    public Transform[] bucketSpawnPositions;

    private Coroutine encounterCoroutine;
    private bool isRoomResetting = false;

    private GameObject[] bucketsOfWater = new GameObject[3];

    override public void EncounterPositionAction()
    {
        encounterCoroutine = StartCoroutine(WaitAndDoSomething());
    }

    private IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        spawner.GetComponent<EnemySpawner>().SpawnEnemies(enemiesToSpawn);
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        while (_managerInstance.enemyCounter > 0)
        {
            yield return null;
        }
        Debug.Log("HE managed");
        _managerInstance.ChangeCurTarget(this.finishPosition);
    }

    public override void ResetCurrentRoom()
    {
        if (encounterCoroutine != null)
        {
            StopCoroutine(encounterCoroutine);
            encounterCoroutine = null;
        }
        spawner.GetComponent<EnemySpawner>().DestroyAllOfEnemies();


        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.enemyCounter = 0; // Сброс счетчика здесь

        for (int i = 0; i < bucketsOfWater.Length; i++)
        {
            if (bucketsOfWater[i] == null)
            {
                bucketsOfWater[i] = Instantiate(bucketOfWaterPrefab, bucketSpawnPositions[i].position, Quaternion.identity);
            }
            else
            {
                bucketsOfWater[i].transform.position = bucketSpawnPositions[i].position;
            }
        }

        this.startPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.encounterPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.finishPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
    }
}
