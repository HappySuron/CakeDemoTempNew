using UnityEngine;

public class SoundManagerMenu : Sounds
{
    // Start is called once before the fir
    
    public static SoundManagerMenu Instance {get; private set;}
    void Start()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
        StartOst();
    }
    void Update()
    {
        
    }

    void StartOst(){
        PlaySound(0, p1:1, p2:1);
    }

}
