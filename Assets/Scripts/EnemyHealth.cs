using UnityEngine;

public class EnemyHealth : Sounds
{
    [SerializeField] private int _health = 10;
    public Animator _animator;
    public EnemyController _enemyController;

    public bool isAlreadyDead;

    public Rigidbody _rigidbody;



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
            GameManagerScript _managerInstance = GameManagerScript.Instance;
            _managerInstance.enemyCounter--;
            _enemyController.enabled = false;
             _rigidbody = GetComponent<Rigidbody>();
            if (_rigidbody != null) _rigidbody.isKinematic = true;
            isAlreadyDead = true;
            _animator.Play("KnifeDeath");
            Destroy(gameObject,5);
        }
    }
}
