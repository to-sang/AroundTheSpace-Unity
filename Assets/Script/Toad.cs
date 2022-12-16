using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{
    public float Range;

    public Transform target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject toadBullet;

    public float fireRate;

    float nextTimeToFire = 0;

    public Transform shootPoint;

    public float Force;

    public GameObject toad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction,Range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                    toad.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    toad.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        if (Detected)
        {
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1/fireRate;
                shoot();
            }
        }
    }
    
    void shoot()
    {
        GameObject BulletToad = Instantiate(toadBullet,shootPoint.position,Quaternion.identity);
        BulletToad.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
