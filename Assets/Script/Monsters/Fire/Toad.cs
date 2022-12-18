using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Toad : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject toadbullet;

    [SerializeField]
    private Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAttack()
    {
        animator.SetBool("attack", false);
    }

    public void attack()
    {
        GameObject go = Instantiate(toadbullet,shootPoint.position,Quaternion.identity);

        Vector3 direction = new Vector3(-transform.localScale.x, 0);

        go.GetComponent<Projectile>().Setup(direction);
    }
}
