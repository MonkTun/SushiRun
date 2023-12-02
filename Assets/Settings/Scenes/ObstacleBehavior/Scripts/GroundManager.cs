using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject ground;
    private float _lastSpawnedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastSpawnedTime + 0.25 < Time.time)
        {
            Instantiate(ground);
            _lastSpawnedTime = Time.time;
        }
    }
}
