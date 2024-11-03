using System;
using UnityEngine;

public class CandlesTrap : Trap
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject poofEffect;
    float effectDuration = 0.3f;

    bool active = true;

    public Sprite candlesOn;
    public Sprite candlesOff;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (active) {
        Debug.Log("Collision detected with: " + other.name);
        if (other.CompareTag("Cake"))
            {
                Debug.Log("Destroying object: " + other.gameObject.name);
                other.GetComponent<PlayerHealth>().TakeDamage(99999);
                GameObject appearEffect = Instantiate(poofEffect, other.transform.position, Quaternion.identity);
                Destroy(appearEffect, effectDuration);
            }       
            else if (other.CompareTag("Player"))
            {
            Debug.Log("set on fire");
            other.GetComponent<MarshBasic>().SetOnFire();

            }
        }

    }

    public override void Act()
    {
        active = false;
        if (spriteRenderer == null)
        {
            return;
        }

        if (candlesOff == null)
        {
            return;
        }
        spriteRenderer.sprite = candlesOff;
    }


    public void ResetTrap(){
        active = true;
        if (spriteRenderer == null)
        {
            return;
        }

        if (candlesOn == null)
        {
            return;
        }
        spriteRenderer.sprite = candlesOn;
    }
}
