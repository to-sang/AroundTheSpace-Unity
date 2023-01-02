using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monsterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public float timeDelayDie;
    // khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
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
            makeDead();
        }
    }

    public void makeDead()
    {

        Destroy(gameObject,timeDelayDie);
    }
}
