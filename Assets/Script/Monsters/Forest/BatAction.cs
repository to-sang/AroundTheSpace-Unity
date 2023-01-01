using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BatAction : MonoBehaviour
{
    public float vanTocVat;
    public bool diChuyenLen = true;
    public float timeDelayDie;

    // dame khi va chamj voiws quasi vatj
    public int dameFromBodyMonster;
    float dameRate = 3f; // thoiwf gian nhaanj dame luot tiep theo
    public float pushBack; // luc bat nguoc lai khi va cham voi monster
    float nextDame; //thoiwf gian nhaanj dame luot tiep theo


    // thanh máu
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth = 0;
    // khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 Dichuyen = transform.localPosition;
        if (diChuyenLen)
        {
            Dichuyen.y += vanTocVat * Time.deltaTime;
        }
        else
        {
            Dichuyen.y -= vanTocVat * Time.deltaTime;
        }
        transform.localPosition = Dichuyen;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            diChuyenLen = false;
        }
        else
        {
            diChuyenLen = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            diChuyenLen = false;
        }
        else
        {
            diChuyenLen = true;
        }
    }

    public void addDamage(int dame)
    {

        currentHealth -= dame;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    void makeDead()
    {
        Die();
        Destroy(gameObject, timeDelayDie);
    }
    public void Die()
    {
        anim.SetBool("isDie", true);
    }
}
