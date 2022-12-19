using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bat : MonoBehaviour, ICollisionHandler
{
    public float vanTocVat;
    public bool diChuyenLen = true;

    private Transform target;

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "damageArea" && other.tag == "Player")
        {
            other.GetComponent<nhanvat>().TakeHit();
        }
        if (colliderName == "sight" && other.tag == "Player")
        {
            if (target == null)
            {
                this.target = other.transform;
            }
        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "sight" && other.tag == "Player")
        {
            target = null;
        }
    }

    private void FixedUpdate()
    {
        Vector2 Dichuyen = transform.localPosition;
        if (diChuyenLen)
        {
            Dichuyen.y += vanTocVat * Time.deltaTime;
        }
        else
        {
            Dichuyen.y -= vanTocVat * Time.deltaTime;
        }
        transform.localPosition = Dichuyen;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            diChuyenLen = false;
        }
        else
        {
            diChuyenLen = true;
        }
    }
    //void QuayMat()
    //{
    //    //Doi huong mat cua cac vat khi doi huong
    //    diChuyenTrai = !diChuyenTrai;
    //    Vector2 huongQuay = transform.localScale;
    //    huongQuay.x *= -1;
    //    transform.localScale = huongQuay;
    //}
}
