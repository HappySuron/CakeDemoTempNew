using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Sounds
{
    public int health = 100;
    public float speed = 2f;

    private int healthMax;

    [SerializeField] private Image healthBar;

    private void Start()
    {
        healthMax = health;
    }

    private void Update()
    {
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        healthBar.fillAmount = (float)health / (float)healthMax;
    }

    public void TakeDamage(int damage)
    {

        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            PlaySound(0, p1: 1, p2: 1);
        }
        else
        {
            health -= damage;
            if (Random.Range(0, 4) == 0)
            {
                PlaySound(1, random: true, p1: 1, p2: 1);
            }
        }
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;

        if (health > healthMax)
        {
            health = healthMax;
        }
    }
}