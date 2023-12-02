using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1f, 1f)]
    private float offset;

    public float scrollSpeed = 0.1f;

    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (Time.time * scrollSpeed)/10f;
        mat.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
        // Debug.Log($"Offset: {offset}");
    }
}
