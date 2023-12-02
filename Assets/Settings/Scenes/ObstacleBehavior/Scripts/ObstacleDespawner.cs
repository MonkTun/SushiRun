using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawner : MonoBehaviour
{
    public float destroyXPosition = -10f; //position to destroy game objects

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
