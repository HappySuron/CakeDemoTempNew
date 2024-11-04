using UnityEngine;

public class RoomVirtual: MonoBehaviour
{
    GameObject curStatePosition;
    int typeStatePosition;

    public Transform startPosition;
    public Transform encounterPosition;
    public Transform finishPosition;
    /*
    - Start
    - Encounter
    - Finish
    */


    public virtual void RoomAction(){
        
    }
    public virtual void OneOfThePosTriggered(int typeOfPos){
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
                GameManagerScript _managerInstance = GameManagerScript.Instance;
            break;
            default:

            break;
        }
    }

    virtual public void StartPositionAction(){
        Debug.Log("StartPosition");
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ChangeCurTarget(this.encounterPosition);
    }


    virtual public void EncounterPositionAction(){
        Debug.Log("EncounterPosition");
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ChangeCurTarget(this.finishPosition);
    }


    virtual public void FinishPositionAction(){
        Debug.Log("FinishPosition");
        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ResetNextRoom();
        _managerInstance.GoAnotherRoom();
    }


    virtual public void ResetCurrentRoom(){
        startPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        encounterPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        finishPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
    }



    virtual public void ActivateAction(){}
}
