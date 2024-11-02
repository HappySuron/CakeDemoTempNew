using Unity.VisualScripting;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    public GameObject explotionEffect;
    public float effectDuration;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var marshBasic = collision.collider.GetComponent<MarshBasic>();
            if (marshBasic != null)
            {
                if (marshBasic.isOnFire)
                {
                    GameObject appearEffect = Instantiate(explotionEffect, transform.position, Quaternion.identity);
                    Destroy(appearEffect, effectDuration);
                    Destroy(this.gameObject);
                    marshBasic.GetComponent<MarshBasic>().OnDeathEvent();
                }
            }
        }
    }
}