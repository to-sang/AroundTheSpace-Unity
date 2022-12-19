using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Toad : MonoBehaviour,ICollisionHandler,IHitable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject toadbullet;

    [SerializeField]
    private Transform shootPoint;

    private Transform target;

    private float attackCooldown;

    private bool canAttack = true;

    private float timeSinceAttack;

    private bool alive = true;

    private void Update()
    {
        if (alive)
        {
            lookAtTarget();
            attack();
        }
        
    }
    public void StopAttack()
    {
        animator.SetBool("attack", false);
    }

    public void shoot()
    {
        GameObject go = Instantiate(toadbullet,shootPoint.position,Quaternion.identity);

        Vector3 direction = new Vector3(-transform.localScale.x, 0);

        go.GetComponent<Projectile>().Setup(direction);
    }

    private void attack()
    {
        if (!canAttack)
        {
            timeSinceAttack += Time.deltaTime;
        }
        if(timeSinceAttack >= attackCooldown)
        {
            canAttack = true;
        }
        if(canAttack && target !=null && Mathf.Abs(target.transform.position.y - transform.position.y) <= 1f)
        {
            canAttack=false;
            timeSinceAttack = 0;
            animator.SetBool("attack", true);
        }

    }

    private void lookAtTarget()
    {
        if(target != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = target.transform.position.x < transform.position.x ? 0.28f : -0.28f;

            transform.localScale = scale;
        }
    }

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
        if(colliderName == "sight" && other.tag == "Player")
        {
            target = null;
        }
    }

    private void Die()
    {
        alive = false;
        animator.SetTrigger("die");
        
    }
    public void TakeHit()
    {
        Die();
        Destroy(gameObject, 1);
    }

}
