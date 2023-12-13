using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 20.0f;

    private float speedincrease = 0.0009f;

    private bool isTrollOne;
    
    // Start is called before the first frame update
    void Start()
    {
        isTrollOne = Random.Range(0, 10f) < 1f;
    }

    // Update is called once per frame
    void Update()
    {
 
        speed = speed + (float)Time.timeSinceLevelLoad * speedincrease;

        if (isTrollOne && speed > 0 && transform.position.x < -4)
        {
            speed = -speed;
            
        }
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
