using UnityEngine;

public class MashKnife : MonoBehaviour
{
    [SerializeField] private bool _hasKnife;
    [SerializeField] private GameObject _knifeObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _knifeObj.SetActive(_hasKnife);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Knife"){
            Destroy(col.gameObject);
            _hasKnife = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Cake"){
            col.gameObject.GetComponent<CakeKnife>().GetKnife();
            _hasKnife = false;
        }
    }
}
