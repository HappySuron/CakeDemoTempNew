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
                EncounterPositionAction();
            break;
            case 3:
                FinishPositionAction();
            break;
            default:

            break;
        }
    }

    override public void EncounterPositionAction()
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


    override public void ResetCurrentRoom(){
        Transform childCandles = transform.Find("candlesTrap");
        if (childCandles != null)
        {
            childCandles.GetComponent<CandlesTrap>().ResetTrap();
        }
        Transform childButton = transform.Find("buttonTrap");
        if (childCandles != null)
        {
            childButton.GetComponent<SimpleButton>().ResetButton();
        }
        this.startPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.encounterPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.finishPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
    }
}
