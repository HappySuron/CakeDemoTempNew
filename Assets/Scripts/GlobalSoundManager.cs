using UnityEngine;

public class GlobalSoundManager : Sounds
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound(sounds[0]);   
        if (Input.GetMouseButtonDown(0)){
            
        }
    }
}
