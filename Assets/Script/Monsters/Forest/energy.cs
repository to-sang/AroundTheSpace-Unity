using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // dame khi va chamj voiws quasi vatj
    public int energy = 30;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            nhanvat nv = col.gameObject.GetComponent<nhanvat>();
            nv.currentHealth = nv.currentHealth + energy;
            Destroy(gameObject);
            Debug.Log("Day la dang nhan roi nha");
        }
    }

    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        nhanvat nv = col.gameObject.GetComponent<nhanvat>();
    //        nv.currentHealth = nv.currentHealth + energy;
    //        Destroy(gameObject);
    //        Debug.Log("Day la dang nhan roi nha");
    //    }
    //}
}
