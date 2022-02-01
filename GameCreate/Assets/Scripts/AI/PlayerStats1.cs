using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats1 : MonoBehaviour
{
    [Header("Characteristics")]
    public float speed;
    public float maxHealth = 100.0f;
    public float minHealth = 0.0f;
    public float currentHealth = 100.0f;
    public float aimness;//точность
    public float damage = 10.0f;
    public bool freedomless;//послушание
    public bool isDead = false;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        gameObject.tag = "Finish";
        //enabled = false;
        isDead = true;
        Destroy(gameObject);

    }
}
