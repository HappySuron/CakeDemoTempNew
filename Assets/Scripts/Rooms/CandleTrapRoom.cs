using System.Collections;
using UnityEngine;

public class CandleTrapRoom : RoomVirtual
{
    override public void OneOfThePosTriggered(int typeOfPos){
        switch (typeOfPos)
        {
            case 0:

            break;
            case 1:
                StartPositionAction();
            break;
            case 2:
                encounterPositionAction();
            break;
            case 3:
                finishPositionAction();
            break;
            default:

            break;
        }
    }

    override public void encounterPositionAction()
    {
        StartCoroutine(WaitAndDoSomething());
    }

    private IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("5 seconds have passed!");
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ChangeCurTarget(this.finishPosition);
    }
}
