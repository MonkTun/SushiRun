using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Vector2 spawnPos = new Vector2(10, 0);
    private float _lastSpawnedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is the part where you can control how fast the obstacles spawn
        float delay = Random.Range(1,3);
        if (_lastSpawnedTime + delay < Time.time)
        {
            int obstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
            Instantiate(ObstaclePrefabs[obstacleIndex], spawnPos, Quaternion.identity);
            _lastSpawnedTime = Time.time;
        }
    }
}