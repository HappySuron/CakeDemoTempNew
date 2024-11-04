using UnityEngine;

public class HeavyButton : MonoBehaviour
{
    private RoomVirtual parentRoom;
    public Trap actingObjext;

    public string requiredTag = "Heavy";

    private bool alreadyPressed = false;


    public Sprite buttonUnpresserd;
    public Sprite buttonPressed;
    private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag)&& !alreadyPressed)
        {
            Debug.Log("PRESSED");
            ActivateObject();
            alreadyPressed = true;
            parentRoom = GetComponentInParent<RoomVirtual>();
            if (parentRoom != null)
            {
                parentRoom.ActivateAction();
            }
        if (spriteRenderer == null)
        {
            return;
        }

        if (buttonPressed == null)
        {
            return;
        }
        spriteRenderer.sprite = buttonPressed;
        }
    }

    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    private void ActivateObject()
    {
        if (actingObjext != null)
        {
            actingObjext.Act();
        }

    }

        public void ResetButton()
    {
        alreadyPressed = false;
        if (spriteRenderer == null)
        {
            return;
        }

        if (buttonUnpresserd == null)
        {
            return;
        }
        spriteRenderer.sprite = buttonUnpresserd;
    }

}
