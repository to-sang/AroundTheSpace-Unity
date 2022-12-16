using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float alivetime;
    // Start is called before the first frame update
    void Start()
    {
            Destroy(gameObject, alivetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
