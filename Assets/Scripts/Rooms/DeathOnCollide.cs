using UnityEngine;

public class DeathOnCollide : MonoBehaviour
{
    public string requiredTag = "Cake";
    public GameObject poofEffect;
    float effectDuration = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
