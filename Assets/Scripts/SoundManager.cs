using UnityEngine;

public class SoundManager : Sounds
{
    // Start is called once before the fir
    /*
        0 - introduction
        1 - changeRoom
        2 - getDamage
        3 - doKill
        4 - lvlUp
        5 - revive
        6 - weapon
    */
    public static SoundManager Instance {get; private set;}
    void Start()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
        PlaySound(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    0 - introduction
    1 - changeRoom
    2 - getDamage
    3 - doKill
    4 - lvlUp
    5 - revive
    6 - weapon
    */
    public void SayIntroductionLine() {
      //  PlaySound(4, random:true, p1:1, p2: 1);
    }

}
