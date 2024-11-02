using UnityEngine;

public class PlayerHealth : Sounds
{
    public int health = 100;

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
}