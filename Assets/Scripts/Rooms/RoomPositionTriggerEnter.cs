using UnityEngine;

public class RoomPositionTriggerEnter : MonoBehaviour
{
    private RoomVirtual parentRoom;
    [SerializeField]
    private int positionType = 0;

    public bool alreadyPassed = false;

    private void Start()
    {
        parentRoom = GetComponentInParent<RoomVirtual>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
    Debug.Log($"Triggered by: {other.gameObject.name} | Already passed: {alreadyPassed}");
    
    if (parentRoom != null && other.CompareTag("Cake"))
    {
        if (!alreadyPassed)
        {
            alreadyPassed = true;
            Debug.Log("Curr type: " + positionType);
            parentRoom.OneOfThePosTriggered(positionType);
        }
        else
        {
            Debug.Log("Already passed this trigger.");
        }
    }
    }

}
