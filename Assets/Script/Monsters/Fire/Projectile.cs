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
        if(collision.tag == targetTag)
        {
            collision.GetComponentInParent<IHitable>().TakeHit();
            Destroy(gameObject);
        }
    }
}
