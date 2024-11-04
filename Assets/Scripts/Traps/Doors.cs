using UnityEngine;

public class Doors : Trap
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject poofEffect;
    float effectDuration = 0.3f;

    bool active = true;

    public Sprite doorsClosed;
    public Sprite doorsOpen;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Act()
    {
        active = false;
        if (spriteRenderer == null)
        {
            return;
        }

        if (doorsOpen == null)
        {
            return;
        }
        spriteRenderer.sprite = doorsOpen;
    }

    


    public void ResetTrap(){
        active = true;
        if (spriteRenderer == null)
        {
            return;
        }

        if (doorsClosed == null)
        {
            return;
        }
        spriteRenderer.sprite = doorsClosed;
    }
}
