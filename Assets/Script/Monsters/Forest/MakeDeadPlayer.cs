using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDeadPlayer : MonoBehaviour
{
    public int dead = 100;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            nhanvat nv = collider2D.gameObject.GetComponent<nhanvat>();
            nv.addDamage(dead);
        }

    }
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            nhanvat nv = collider2D.gameObject.GetComponent<nhanvat>();
            nv.addDamage(dead);
        }
    }
}
