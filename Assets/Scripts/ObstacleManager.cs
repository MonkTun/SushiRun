using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Vector2 spawnPos = new Vector2(10, 0);
    private float _lastSpawnedTime;
    public float delay = 1;
    private float speedincrease = 0.0001f;
    
    private int numberOfObstacleSpawned;

    void Awake()
    {
        delay = 2;
        Application.targetFrameRate = 240;
    }

    // Update is called once per frame
    void Update()
    {
        //this is the part where you can control how fast the obstacles spawn
        if (_lastSpawnedTime + delay < Time.time)
        {
            print(delay);
            int obstacleIndex = Random.Range(0, ObstaclePrefabs.Length);
            Instantiate(ObstaclePrefabs[obstacleIndex], spawnPos, Quaternion.identity);
            numberOfObstacleSpawned++;
            _lastSpawnedTime = Time.time;
            delay = Mathf.Clamp(Random.Range(1.5f, 3f) - 0.05f * numberOfObstacleSpawned, 0.6f, 2);
        }
    }
} 