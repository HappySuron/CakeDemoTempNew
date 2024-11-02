using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance {get; private set;}
    [SerializeField] 
    public List<GameObject> rooms;
    private int indexRoom = 0;
    public GameObject cake;

    Transform curTargetPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance != null && Instance != this){
             Destroy(this);
         }else{
             Instance = this;
         }
       
    }

    void Update(){
         MoveCake(rooms[indexRoom].GetComponent<RoomVirtual>().startPosition.transform.position);
    }



    private void MoveCake(Vector3 targetPosition)
    {
        float speed = cake.GetComponent<PlayerHealth>().speed;
        Debug.Log(targetPosition);
        cake.transform.position = Vector3.MoveTowards(cake.transform.position, targetPosition, speed * Time.deltaTime);
        
    }



}
