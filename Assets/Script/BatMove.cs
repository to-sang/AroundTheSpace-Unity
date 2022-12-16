using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public float vanTocVat;
    public bool diChuyenLen = true;

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
