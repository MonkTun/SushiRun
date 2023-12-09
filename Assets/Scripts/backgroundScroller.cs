using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    private float offset;

    private float scrollSpeed = 1.0f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        // InvokeRepeating to call IncreaseSpeed function every 10 seconds
        InvokeRepeating("IncreaseSpeed", 0f, 3f);
    }

    void Update()
    {
        offset = (Time.time * scrollSpeed) / 10.0f;
        mat.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
    }

    // Function to increase speed
    void IncreaseSpeed()
    {
        scrollSpeed += 1.0f;
        Debug.Log($"Speed increased to: {scrollSpeed}");
    }
}