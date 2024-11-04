using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance {get; private set;}
    [SerializeField] 
    public List<GameObject> rooms;
    public int indexRoom = 0;
    public GameObject cake;

    public bool isReadyToMove = false;

    Transform curTargetPosition;

    public Animator animatorCake;

    public Transform finalleSpot;


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
        if (indexRoom< rooms.Count)
            curTargetPosition = rooms[indexRoom].GetComponent<RoomVirtual>().startPosition.transform;
    }

    public void ChangeCurTarget(Transform newPos){
        curTargetPosition = newPos;
    }

    void Update(){
        if (isReadyToMove && cake!=null){
         MoveCake(curTargetPosition.position);
         animatorCake.SetBool("isMove",isReadyToMove);}
        if (Mathf.Abs(curTargetPosition.position.x - cake.transform.position.x) < 0.1f)
        {
            animatorCake.SetBool("isMove",false);
        }
        
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
        if (indexRoom + 1 < rooms.Count){
            rooms[indexRoom+1].GetComponent<RoomVirtual>().ResetCurrentRoom();
        }
        else{
        
        if (FadeOutManager.Instance != null)
        {
            FadeOutManager.Instance.StartFadeOut(1f);
        }
        }
    }

    public void StartGame(){
        isReadyToMove = true;
    }
}
