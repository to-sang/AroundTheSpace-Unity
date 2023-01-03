using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{

    public int dame; 
    fire myfire;
    public GameObject bulletExplosion;
    private void Awake()
    {
        myfire = GetComponent<fire>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Monter" || col.gameObject.tag == "NenDat")
        {
            myfire.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletExplosion);
            if(col.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                monsterHealth healthMonster = col.gameObject.GetComponent<monsterHealth>();
                healthMonster.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("enemy1"))
            {
                TakeDame takeDame = col.gameObject.GetComponent<TakeDame>();
                takeDame.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("enemy2"))
            {
                BatAction batAction = col.gameObject.GetComponent<BatAction>();
                batAction.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("boss"))
            {
                BatAction batAction = col.gameObject.GetComponent<BatAction>();
                batAction.addDamage(5);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monter" || col.gameObject.tag == "NenDat")
        {
            myfire.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletExplosion);
            if (col.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                monsterHealth healthMonster = col.gameObject.GetComponent<monsterHealth>();
                healthMonster.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("enemy1"))
            {
                TakeDame takeDame = col.gameObject.GetComponent<TakeDame>();
                takeDame.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("enemy2"))
            {
                BatAction batAction = col.gameObject.GetComponent<BatAction>();
                batAction.addDamage(dame);
            }
            else if (col.gameObject.layer == LayerMask.NameToLayer("boss"))
            {
                BatAction batAction = col.gameObject.GetComponent<BatAction>();
                batAction.addDamage(5);
            }
        }
    }
}
