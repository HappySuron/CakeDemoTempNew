using UnityEngine;

public class EnemyController : Sounds
{
    public Animator _animator;
    public SpriteRenderer _spriteRenderer;
    public float speed = 3.0f;
    public float attackRange = 0.5f;
    public int damage = 10;
    //private Transform target;
    private Rigidbody2D rb;

    public GameObject poofEffect;

    public float effectDuration = 0.3f;

    public GameObject exclamationMarkPrefab;
    public float exclamationMarkHeight = 1.5f;
    private GameObject currentExclamationMark;

    public enum State
    {
        Idle,
        Chasing,
        Attacking,
        Cooldown
    }

    public State currentState = State.Idle;
    public GameObject targetUnit;
    public float chaseRange = 10f;
    public float attackTime = 1f;
    public float cooldownTime = 2f;

    private float attackTimer;
    private float cooldownTimer;


    private void Start()
    {
        SetState(State.Idle);
        targetUnit = GameObject.FindGameObjectWithTag("Cake");
        rb = GetComponent<Rigidbody2D>();
        PlaySound(0);
        GameObject appearEffect = Instantiate(poofEffect, this.transform.position, Quaternion.identity);
        Destroy(appearEffect, effectDuration);
    }


    private void Update()
    {
        

        if(rb.linearVelocityX < 0){
            _spriteRenderer.flipX = true;
        }else{
            _spriteRenderer.flipX = false;
        }

        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Chasing:
                Chase();
                break;
            case State.Attacking:
                Attack();
                break;
            case State.Cooldown:
                Cooldown();
                break;
        }
        // MoveTowardsPlayer();
        // CheckAttack();
    }


    private void Idle()
    {
        if (targetUnit != null)
        {
            _animator.Play("Idle");
            SetState(State.Chasing);
        }
    }


    private void Chase()
    {
        if (targetUnit != null)
        {
            MoveTowardsPlayer();
            _animator.Play("KnifeRun");

            float distanceToTargetUnit = Vector3.Distance(transform.position, targetUnit.transform.position);
            if (distanceToTargetUnit > chaseRange)
            {
                SetState(State.Idle);
            }
            else if (distanceToTargetUnit <= attackRange)
            {
                SetState(State.Attacking);
            }
        }
        else
        {
            SetState(State.Idle);
        }
    }

    private void Attack()
    {
        // Vector2 curPosition = this.transform.position.normalized;
        // rb.MovePosition(rb.position + curPosition * speed * Time.deltaTime);
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            targetUnit.GetComponent<PlayerHealth>().TakeDamage(damage);
            _animator.Play("Attack");
            HideExclamationMark();
            PlaySound(1, random: true);
            SetState(State.Cooldown); // Перейти в состояние Cooldown после атаки
        }
    }


    private void Cooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            float distanceToTargetUnit = Vector3.Distance(transform.position, targetUnit.transform.position);

            if (distanceToTargetUnit <= attackRange)
            {
                // Если враг находится в радиусе атаки, перейти в состояние атаки
                SetState(State.Attacking);
            }
            else if (distanceToTargetUnit <= chaseRange)
            {
                // Если враг находится в радиусе погони, перейти в состояние погони
                SetState(State.Chasing);
            }
            else
            {
                // В противном случае вернуться в состояние Idle
                SetState(State.Idle);
            }
        }
    }

    public void SetState(State newState)
    {
        currentState = newState;

        if (newState == State.Attacking)
        {
            attackTimer = attackTime;
            ShowExclamationMark();
        }
        else if (newState == State.Cooldown)
        {
            cooldownTimer = cooldownTime;
        }
    }


    private void MoveTowardsPlayer()
    {
        // Основное направление к игроку
        Vector2 direction = (targetUnit.transform.position - transform.position).normalized;
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


    private void ShowExclamationMark()
    {
        if (currentExclamationMark == null)
        {
            Vector3 exclamationMarkPosition = transform.position + Vector3.up * exclamationMarkHeight;
            currentExclamationMark = Instantiate(exclamationMarkPrefab, exclamationMarkPosition, Quaternion.identity);
            _animator.Play("Warning");
            currentExclamationMark.transform.SetParent(transform);
        }
    }

    private void HideExclamationMark()
    {
        if (currentExclamationMark != null)
        {
            Destroy(currentExclamationMark);
            currentExclamationMark = null;
        }
    }
    // private void CheckAttack()
    // {
    //     if (Vector2.Distance(transform.position, targetUnit.position) <= attackRange)
    //     {
    //         // Нанесение урона главному герою
    //         targetUnit.GetComponent<PlayerHealth>().TakeDamage(damage);
    //     }
    // }
}