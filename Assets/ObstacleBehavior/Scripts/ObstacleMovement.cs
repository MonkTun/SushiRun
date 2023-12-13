using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 20.0f;

    private float speedincrease = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + (float)Time.timeSinceLevelLoad * speedincrease;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
