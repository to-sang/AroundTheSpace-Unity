using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDame : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    // dame khi va chamj voiws quasi vatj
    public int dameFromBodyMonster=10;
    float dameRate = 3f; // thoiwf gian nhaanj dame luot tiep theo
    float nextDame; //thoiwf gian nhaanj dame luot tiep theo
    // Start is called before the first frame update
    void Start()
    {
        nextDame = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDame < Time.time)
        {
            nhanvat nv = collision.gameObject.GetComponent<nhanvat>();
            nv.addDamage(dameFromBodyMonster);
            nextDame = dameRate + Time.time;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDame < Time.time)
        {
            nhanvat nv = collision.gameObject.GetComponent<nhanvat>();
            nv.addDamage(dameFromBodyMonster);
            nextDame = dameRate + Time.time;
        }
    }
}
