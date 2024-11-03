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

    public bool isReadyToMove = false;

    Transform curTargetPosition;

    void Start()
    {
        if(Instance != null && Instance != this){
             Destroy(this);
         }else{
             Instance = this;
         }
       curTargetPosition = rooms[0].GetComponent<RoomVirtual>().startPosition.transform;
    }

    public void GoAnotherRoom(){
        indexRoom++;
        curTargetPosition = rooms[indexRoom].GetComponent<RoomVirtual>().startPosition.transform;
    }

    public void ChangeCurTarget(Transform newPos){
        curTargetPosition = newPos;
    }

    void Update(){
        if (isReadyToMove && cake!=null)
         MoveCake(curTargetPosition.position);
    }



    private void MoveCake(Vector3 targetPosition)
    {
        float speed = cake.GetComponent<PlayerHealth>().speed;
        Debug.Log(targetPosition);
        cake.transform.position = Vector3.MoveTowards(cake.transform.position, targetPosition, speed * Time.deltaTime);
    }
}
