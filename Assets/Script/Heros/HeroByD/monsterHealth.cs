using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHealth : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
