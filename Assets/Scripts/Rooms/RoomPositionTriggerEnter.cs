using UnityEngine;

public class RoomPositionTriggerEnter : MonoBehaviour
{
    private RoomVirtual parentRoom;
    [SerializeField]
    private int positionType = 0;

    private void Start()
    {
        parentRoom = GetComponentInParent<RoomVirtual>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AAAAAAAAAAA");
        if (parentRoom != null && other.CompareTag("Cake"))
        {
            parentRoom.OneOfThePosTriggered(positionType);
        }
    }

}
