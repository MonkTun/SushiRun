using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    

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
        if (GameManager.Instance.score % 10 == 0 && GameManager.Instance.score != lastSpawned)
        {
            print(lastSpawned);
            lastSpawned = GameManager.Instance.score;
            Instantiate(powerups[Random.Range(0, powerups.Length)], new Vector2(10, 1), Quaternion.identity);
        }
    }
}
