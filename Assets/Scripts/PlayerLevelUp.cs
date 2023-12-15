using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    public int Level = 10;
    public float canLevelUp = 1f; //amount of seconds it takes per level up
    public SpriteRenderer squareColor;
    
    void _PlayerLevelUp(int l)
    {
        if(Time.timeSinceLevelLoad > canLevelUp && Level == l)
        { 
            print("level is" + l);
             // need to add a change of sprite when we get the art for sprites
            Level = Level + 1;
            canLevelUp = canLevelUp + 20; // change float to increase time per level up
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        _PlayerLevelUp(1);
        _PlayerLevelUp(2);
        _PlayerLevelUp(3);
        _PlayerLevelUp(4);
        _PlayerLevelUp(5);
        _PlayerLevelUp(6);
        _PlayerLevelUp(7);
        _PlayerLevelUp(8);
    }   
}
