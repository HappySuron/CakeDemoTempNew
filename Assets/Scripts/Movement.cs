using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод с клавиш WASD
        movement.x = Input.GetAxisRaw("Horizontal"); // Для A и D
        movement.y = Input.GetAxisRaw("Vertical"); // Для W и S
    }
    
    void FixedUpdate()
    {
        // Перемещаем персонажа
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
