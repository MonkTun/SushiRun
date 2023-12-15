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
        if (GameManager.Instance.score > 75) 
            isTrollOne = Random.Range(0, 10f) < 0.5f;

        if (isTrollOne)
        {
            foreach (SpriteRenderer spriteRenderer in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
 
        speed = speed + (float)Time.timeSinceLevelLoad * speedincrease;

        if (isTrollOne && speed > 0 && transform.position.x < -3)
        {
            speed = -speed;
            
        }
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
