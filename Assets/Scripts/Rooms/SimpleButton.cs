using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public Trap actingObjext;

    public string requiredTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag))
        {
            ActivateObject();
        }
    }

    private void ActivateObject()
    {
        if (actingObjext != null)
        {
            actingObjext.Act();
        }

    }
}
