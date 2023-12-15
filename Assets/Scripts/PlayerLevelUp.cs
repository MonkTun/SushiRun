using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    public int level { get; private set; }
    public float canLevelUp = 1f; //amount of seconds it takes per level up
    public SpriteRenderer squareColor;
    public Animator Animator;
    public ParticleSystem levelupParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }
    
    
    void _PlayerLevelUp(int l)
    {
        if(Time.timeSinceLevelLoad > canLevelUp && level == l)
        { 
            // need to add a change of sprite when we get the art for sprites
            level++;
            print("level is" + level);
            Animator.SetInteger("PlayerLevel", level);
            canLevelUp = canLevelUp + 20; // change float to increase time per level up
            if (level != 1)
            {
                levelupParticleSystem.Play();
                SoundManager.Instance.GeneralPlaySoundEffect("Upgrade_Sound");
            }
        }
            
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
    }   
}