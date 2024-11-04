using System.Collections;
using UnityEngine;

public class EnemyEncounterRoom : RoomVirtual
{

    public   int enemiesToSpawn = 1;
    public GameObject spawner;
    public GameObject redBarrelPrefab;
    public Transform redBarrelPlaceToSpawn;


    private Coroutine encounterCoroutine;
    private bool isRoomResetting = false;

    GameObject redBarrel;

    override public void EncounterPositionAction()
    {
         encounterCoroutine = StartCoroutine(WaitAndDoSomething());
    }

    private IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        spawner.GetComponent<EnemySpawner>().SpawnEnemies(enemiesToSpawn);
        Debug.Log("Спавним врагов...");
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
        if (redBarrel == null)
        {
            redBarrel = Instantiate(redBarrelPrefab, redBarrelPlaceToSpawn.position, Quaternion.identity);
        }
        else
        {
            redBarrel.transform.position = redBarrelPlaceToSpawn.position;
        }
        this.startPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.encounterPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.finishPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
    }

        override public void FinishPositionAction(){
        Debug.Log("FinishPosition");
        SoundManager _managerSoundInstance = SoundManager.Instance;
        _managerSoundInstance.PlaySound(4, random:true, p1:1, p2:1);


        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ResetNextRoom();
        _managerInstance.GoAnotherRoom();
    }
}
