using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasabiItem : PowerUpItem
{
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        print("item!");
        Destroy(gameObject);
    }
}
