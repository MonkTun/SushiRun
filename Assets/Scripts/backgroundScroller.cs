using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1f, 1f)]
    private float offset;

    public float scrollSpeed = 0.1f;

    // public float accel = 10.0f;
    
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // increase speed every 10 seconds NEEDS FIXING (Invoke Repeating)
        if (Mathf.FloorToInt(Time.deltaTime) % 10 == 0)
        {
            scrollSpeed += 0.1f;
        }
        offset = (Time.time * scrollSpeed)/10.0f;
        mat.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
        // Debug.Log($"Offset: {offset}");
    }
}
