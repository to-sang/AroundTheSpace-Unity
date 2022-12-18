using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private ICollisionHandler handler;

    private void Start()
    {
        handler = GetComponentInParent<ICollisionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        handler.CollisionEnter(gameObject.name, collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        handler.CollisionExit(gameObject.name, collision.gameObject);
    }
}
