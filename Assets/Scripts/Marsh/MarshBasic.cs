using UnityEngine;
using System.Collections;

public class MarshBasic : Sounds
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isOnFire = false;
    private Coroutine fireCoroutine;
    
    private SpriteRenderer childSpriteRenderer;
    public Sprite fireSprite;

    
    
    
    public Camera mainCamera;
    public Transform teleportCenter;
    public float teleportRadius = 2f;
    public float offset = 0.5f;
    public GameObject poofEffect;
    public float effectDuration = 0.1f;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetOnFire()
    {       
        Transform childTransform = transform.Find("effect");
            if (childTransform != null)
            {
                SpriteRenderer childSpriteRenderer = childTransform.GetComponent<SpriteRenderer>();
                if (childSpriteRenderer != null)
                {
                    childSpriteRenderer.sprite = fireSprite;
                }
            }
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
        fireCoroutine = StartCoroutine(OnFireCoroutine());
    }

    private IEnumerator OnFireCoroutine()
    {
        isOnFire = true;
        Debug.Log("Character is on fire!");
        yield return new WaitForSeconds(5f);
        isOnFire = false; 
        Debug.Log("Character is no longer on fire.");
        fireCoroutine = null;
        OnDeathEvent();
    }



    public void OnDeathEvent(){
        isOnFire = false;
        Transform childTransform = transform.Find("effect");
        if (childTransform != null)
        {
        SpriteRenderer childSpriteRenderer = childTransform.GetComponent<SpriteRenderer>();
            if (childSpriteRenderer != null)
            {
                childSpriteRenderer.sprite = null;
            }
        }
        Vector2 randomOffset = Random.insideUnitCircle * teleportRadius;
        if (teleportCenter!=null){
            Vector3 newPosition = new Vector3(teleportCenter.position.x + randomOffset.x, teleportCenter.position.y + randomOffset.y, transform.position.z);
            transform.position = newPosition;
            PlaySound(0);
            GameObject appearEffect = Instantiate(poofEffect, newPosition, Quaternion.identity);
            Destroy(appearEffect, effectDuration);
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, mainCamera.nearClipPlane));
        Vector3 screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, mainCamera.nearClipPlane));
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, mainCamera.nearClipPlane));

        bool isTeleported = false;

        if (transform.position.x < screenLeft.x - offset || transform.position.x > screenRight.x + offset)
        {
            isTeleported = true;
        }
        if (transform.position.y < screenBottom.y - offset || transform.position.y > screenTop.y + offset)
        {
            isTeleported = true;
        }

        if (isTeleported)
        {
            OnDeathEvent(); 
        }
    }
}
