using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 vitri = transform.position;
            vitri.x = player.position.x;
            if(vitri.x < minX)
                vitri.x = minX;
            if(vitri.x > maxX)
                vitri.x = maxX;
            vitri.y = player.position.y + 1;
            if (vitri.y < minY)
                vitri.y = minY;
            if (vitri.y > maxY)
                vitri.y = maxY;
            transform.position = vitri;
        }
    }
}
