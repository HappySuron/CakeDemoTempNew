using UnityEngine;

public class MarshTeleport : Sounds
{
    public Camera mainCamera;
    public Transform teleportCenter;
    public float teleportRadius = 2f;
    public float offset = 0.5f;
    public GameObject poofEffect;
    public float effectDuration = 0.1f;

    void Update()
    {
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
            Vector2 randomOffset = Random.insideUnitCircle * teleportRadius;
            Vector3 newPosition = new Vector3(teleportCenter.position.x + randomOffset.x, teleportCenter.position.y + randomOffset.y, transform.position.z);
            transform.position = newPosition;
            PlaySound(0);
            GameObject appearEffect = Instantiate(poofEffect, newPosition, Quaternion.identity);
            Destroy(appearEffect, effectDuration);
        }
    }
}
