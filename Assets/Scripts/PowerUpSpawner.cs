using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private int spawnPointInterval = 30;    

    [SerializeField]
    private GameObject[] powerups;

    private int lastSpawned;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)GameManager.Instance.score % spawnPointInterval == 0 && (int)GameManager.Instance.score != lastSpawned)
        {
            print(lastSpawned);
            lastSpawned = (int)GameManager.Instance.score;
            Instantiate(powerups[Random.Range(0, powerups.Length)], new Vector2(10, 1), Quaternion.identity);
        }
    }
}
