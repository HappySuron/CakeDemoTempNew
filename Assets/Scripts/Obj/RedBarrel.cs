using Unity.VisualScripting;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float damageRadius = 10f;
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
                    DamageOnExplosion();

                    GameObject appearEffect = Instantiate(explotionEffect, transform.position, Quaternion.identity);
                    Destroy(appearEffect, effectDuration);
                    Destroy(this.gameObject);
                    marshBasic.GetComponent<MarshBasic>().OnDeathEvent();
                }
            }
        }
    }

    private void DamageOnExplosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.gameObject.GetComponent<EnemyHealth>().GetDamage(_damage);
            }
        }
    }
}