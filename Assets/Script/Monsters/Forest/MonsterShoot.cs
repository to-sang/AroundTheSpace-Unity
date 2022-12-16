using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public float dame;
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
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "NenDat")
        {
            myfire.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletExplosion);
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                nhanvat nv = col.gameObject.GetComponent<nhanvat>();
                nv.addDamage(dame);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "NenDat")
        {
            myfire.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(bulletExplosion);
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                nhanvat nv = col.gameObject.GetComponent<nhanvat>();
                nv.addDamage(dame);
            }
        }
    }
}
