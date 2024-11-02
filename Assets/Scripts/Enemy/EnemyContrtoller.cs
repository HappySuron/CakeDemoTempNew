using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public float attackRange = 0.5f;
    public int damage = 10;
    private Transform target;
    private Rigidbody2D rb;

    private void Start()
    {
        // target = GameObject.FindGameObjectWithTag("Cake").transform;
        // rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveTowardsPlayer();
        CheckAttack();
    }

   private void MoveTowardsPlayer()
{
    // Основное направление к игроку
    Vector2 direction = (target.position - transform.position).normalized;
    Vector2 avoidanceVector = Vector2.zero;

    // Найти всех врагов в радиусе и корректировать направление
    Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, 0.5f);
    foreach (var neighbor in neighbors)
    {
        if (neighbor != this.GetComponent<Collider2D>() && neighbor.CompareTag("Enemy"))
        {
            Vector2 diff = transform.position - neighbor.transform.position;
            avoidanceVector += diff.normalized / diff.sqrMagnitude; // Добавляем вектор избегания
        }
    }

    // Уменьшаем влияние avoidanceVector, чтобы враги меньше отклонялись
    Vector2 movement = (direction + avoidanceVector * 0.5f).normalized; 
    rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
}

    private void CheckAttack()
    {
        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            // Нанесение урона главному герою
            target.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}