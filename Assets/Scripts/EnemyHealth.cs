using UnityEngine;

public class EnemyHealth : Sounds
{
    [SerializeField] private int _health = 10;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage){
        _health -= damage;
        if(_health <= 0) {
            PlaySound(0, p1: 1, p2: 1, destroyed:true, random: true);
            Debug.Log("Enemy " + gameObject.name + " is dead");
            Destroy(gameObject);
        }
    }
}
