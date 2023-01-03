using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{
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
            nv.currentHealth = Mathf.Min(nv.currentHealth + energy,nv.maxHealth);
            Destroy(gameObject);
        }
    }
}
