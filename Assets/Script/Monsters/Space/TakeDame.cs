using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TakeDame : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth = 0;
    public float timeDelayDie;
    // khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(int dame)
    {

        currentHealth -= dame;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Debug.Log(transform.name);
            if (transform.name == "Boss")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
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
        anim.SetBool("isDeath", true);
    }
    
}
