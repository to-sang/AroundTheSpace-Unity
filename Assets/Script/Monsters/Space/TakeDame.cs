using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TakeDame : MonoBehaviour, IHitable
{
    [SerializeField] private int maxHP;
    private Animator anim;
    private int curHP;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        anim.SetBool("isDeath", true);
    }
    public void TakeHit()
    {
        Die();
        Destroy(gameObject, 1);
    }
}
