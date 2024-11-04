using UnityEngine;

public class CrushInTheDoorTp : MonoBehaviour
{
    public Transform tpPlace;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            other.transform.position = tpPlace.position;
        }
    }
}
