using System.Collections;
using UnityEngine;

public class DoorRoomWithStatue : RoomVirtual
{
    public bool actionActivated = false;

    override public void EncounterPositionAction()
    {
        StartCoroutine(WaitAndDoSomething());
    }

    private IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("5 seconds have passed!");
        while (!actionActivated)
        {
            yield return null;
        }

        GameManagerScript _managerInstance = GameManagerScript.Instance;
        _managerInstance.ChangeCurTarget(this.finishPosition);
    }
    override public void ActivateAction()
    {
        actionActivated = true;
    }

    override public void ResetCurrentRoom()
    {
        actionActivated = false;

        Transform childButton = transform.Find("heavyButton");
        if (childButton != null)
        {
            childButton.GetComponent<HeavyButton>().ResetButton();
        }
        Transform childStatue = transform.Find("cakeStatue");
        Transform childStatuePos = transform.Find("cakeStatuePos");
        if (childButton != null && childStatuePos!=null)
        {
            childStatue.transform.position = childStatuePos.transform.position;
        }
        this.startPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.encounterPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
        this.finishPosition.GetComponent<RoomPositionTriggerEnter>().alreadyPassed = false;
    }
}