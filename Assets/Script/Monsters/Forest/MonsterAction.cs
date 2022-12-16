using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    public float vanTocVat;
    public int hp = 100;
    public bool right = false;
    private Animator hd;
    float fireRate = 0.5f;
    float nextFire = 0;
    public GameObject bullet;
    public Transform monsterShoot; // vi tri quái bắn đạn
    private Rigidbody2D rigidbody2d;
    Vector2 Dichuyen;
    Vector2 chuyenhuong;


    void Start()
    {
        hd = GetComponent<Animator>();
        Dichuyen = transform.position;  
        chuyenhuong = transform.localScale;
    }
    private void Update()
    {
        hd.SetBool("right", right);
    }
    private void FixedUpdate()
    {
        if (right)
        {
            Dichuyen.x += vanTocVat * Time.deltaTime;
        }
        else if(!right)
        {
            Dichuyen.x -= vanTocVat * Time.deltaTime;
        }
        transform.localPosition = Dichuyen;
        transform.localScale = chuyenhuong;
        //// chức năng bắn
        if (Time.time % 2 == 0 && hp > 0)
        {
            fireBullet();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.x > 0)
        {
            right = true;

        }
        else
        {
            chuyenhuong.x *= -1;
            right = false;
        }
        transform.localScale = chuyenhuong;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.x > 0)
        {
            right = true;
        }
        else
        {
            chuyenhuong.x *= -1;
            right = false;
           
        }
        //transform.localScale = chuyenhuong;
    }


    // chuc nang ban dan

    void fireBullet()
    {
        if (Time.time > nextFire)
       {
            nextFire = Time.time + fireRate;
            if (right)
            {
                Instantiate(bullet, monsterShoot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!right)
            {
                Instantiate(bullet, monsterShoot.position, Quaternion.Euler(new Vector3(0, 0, 180)));

            }
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
