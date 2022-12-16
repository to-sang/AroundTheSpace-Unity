using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_LavaScroller : MonoBehaviour
{
    private Material mat;
    private float offset;

    [Range(-1f,1f)]
    public float speed = 0.5f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * speed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
