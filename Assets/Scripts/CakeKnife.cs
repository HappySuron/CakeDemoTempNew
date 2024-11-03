using UnityEngine;

public class CakeKnife : MonoBehaviour
{
    [SerializeField] private bool _hasKnife;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _knifeObj;
    [SerializeField] private float searchRadius = 10f;

    [SerializeField] private float cooldownTime = 2f;
    private float attackTimer;

    public void GetKnife()
    {
        _hasKnife = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = cooldownTime;
        //test
    }

    // Update is called once per frame
    void Update()
    {
        _knifeObj.SetActive(_hasKnife);

        if (_hasKnife)
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);

            GameObject closestObject = null;
            float shortestDistance = Mathf.Infinity;

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    float distanceToTarget = Vector2.Distance(transform.position, collider.transform.position);

                    if (distanceToTarget < shortestDistance)
                    {
                        closestObject = collider.gameObject;
                        shortestDistance = distanceToTarget;
                    }
                }
            }


            if (closestObject != null)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    _hasKnife = false;
                    attackTimer = cooldownTime;
                    closestObject.GetComponent<EnemyHealth>().GetDamage(_damage);
                }
            }
        }
    }
}
