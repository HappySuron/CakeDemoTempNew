using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public Trap actingObjext;

    public string requiredTag = "Player";

    private bool alreadyPressed = false;


    public Sprite buttonUnpresserd;
    public Sprite buttonPressed;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not attached to the CandlesTrap GameObject.");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag)&& !alreadyPressed)
        {
            ActivateObject();
            alreadyPressed = true;
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
