using System.Collections;
using UnityEngine;

public class EnemyEncounterRoom : RoomVirtual
{

    public GameObject spawner;

    override public void encounterPositionAction()
    {
        StartCoroutine(WaitAndDoSomething());
    }

    private IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
        spawner.GetComponent<EnemySpawner>().SpawnEnemies(1);
        Debug.Log("Спавним врагов...");
        GameManagerScript _managerInstance = GameManagerScript.Instance;


        while (_managerInstance.enemyCounter > 0)
        {
            yield return null; // Ждем следующего кадра
        }
        _managerInstance.ChangeCurTarget(this.finishPosition);



    }

    
}
