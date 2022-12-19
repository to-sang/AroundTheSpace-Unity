using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 direction;

    [SerializeField]
    private string targetTag;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

    }

    public void Setup( Vector2 direction)
    {
        this.direction = direction;

        GetComponent<SpriteRenderer>().flipX = direction.x == 1 ? false : true;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //try
        //{

            Debug.Log(collision + "1" + collision.tag);
            if (collision.tag == targetTag)
            {
                Debug.Log(collision + "2");
                collision.GetComponentInParent<IHitable>().TakeHit();
                Debug.Log(collision + "3");
                Destroy(gameObject);
                Debug.Log(collision + "4");
            }
        //} 
        //catch (Exception ex)
        //{
        //    Debug.Log(collision + "5");
        //}
    }
}
