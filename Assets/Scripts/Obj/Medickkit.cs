using UnityEngine;

public class Medickkit : MonoBehaviour
{
    [SerializeField] private int _healthToAdd = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Cake"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().AddHealth(_healthToAdd);
            Destroy(gameObject);
        }
    }
}
