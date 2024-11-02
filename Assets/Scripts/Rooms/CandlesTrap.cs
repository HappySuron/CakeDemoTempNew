using System;
using UnityEngine;

public class CandlesTrap : Trap
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string requiredTag = "Cake";
    public GameObject poofEffect;
    float effectDuration = 0.3f;

    bool active = true;

    public Sprite newSprite;
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
        if (active) {
        Debug.Log("Collision detected with: " + other.name);
        if (other.CompareTag(requiredTag))
            {
                Debug.Log("Destroying object: " + other.gameObject.name);
                Destroy(other.gameObject);
                GameObject appearEffect = Instantiate(poofEffect, other.transform.position, Quaternion.identity);
                Destroy(appearEffect, effectDuration);
            }
        }
    }

    public override void Act()
    {
        active = false;
        Debug.Log("Act() method called in CandlesTrap");

        if (spriteRenderer == null)
        {
            Debug.LogError("spriteRenderer is null in Act()");
            return;
        }

        if (newSprite == null)
        {
            Debug.LogError("newSprite is null in Act()");
            return;
        }

        // Change the sprite to newSprite
        spriteRenderer.sprite = newSprite;
        Debug.Log("Sprite has been changed to newSprite");
    }
}
