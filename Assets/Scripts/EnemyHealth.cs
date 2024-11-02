using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        if(_health <= 0){
            Debug.Log("Enemy " + gameObject.name + " is dead");
            Destroy(gameObject);
        }
    }
}
