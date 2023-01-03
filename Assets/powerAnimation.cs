using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerAnimation : MonoBehaviour
{
    bool check = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color32 color = transform.GetComponent<Renderer>().material.color;
        if (check)
        {
            color.r += 1;
            color.b += 1;
        }
        else
        {
            color.r -= 1;
            color.b -= 1;
        }

        if(color.r < 10)
        {
            check = true;
        }
        if(color.r > 245)
        {
            check= false;
        }

    }
}
