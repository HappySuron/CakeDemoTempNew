using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance {get; private set;}
    [SerializeField] 
    public List<GameObject> rooms;
    public int indexRoom = 0;
    public GameObject cake;

    public bool isReadyToMove = false;

    Transform curTargetPosition;


    public int enemyCounter;

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
        Debug.Log("GoAnotherRoomMan");
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
       // Debug.Log(targetPosition);
        cake.transform.position = Vector3.MoveTowards(cake.transform.position, targetPosition, speed * Time.deltaTime);
    }


    public void StartFromCheckpoint(){
        if (cake!=null){
            curTargetPosition = rooms[indexRoom].GetComponent<RoomVirtual>().startPosition;
            cake.transform.position = curTargetPosition.position;
            cake.GetComponent<PlayerHealth>().health = cake.GetComponent<PlayerHealth>().healthMax;
            rooms[indexRoom].GetComponent<RoomVirtual>().ResetCurrentRoom();
        }
    }


    public void ResetNextRoom(){
        if (rooms[indexRoom+1]!=null)
            rooms[indexRoom+1].GetComponent<RoomVirtual>().ResetCurrentRoom();
    }

    public void StartGame(){
        isReadyToMove = true;
    }
}
