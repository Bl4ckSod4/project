using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats1 : MonoBehaviour
{
    //класс с параметрами солдата
    [Header("Characteristics")]
    public float speed;//скорость ходьбы
    //public float maxHealth = 100.0f;//максимальное здоровье
    //public float minHealth = 0.0f;//минимальное здоровье
    public float currentHealth = 100.0f;//текущее здоровье
    //public float aimness;//разброс
    //public float damage = 10.0f;//урон
    public bool freedomless;//послушание
    public bool isDead = false;//флаг, показывающий что текущая цель уничтожена и возврат в Idle
    
    public void TakeDamage(float Damage)//наносит урон здоровью при попадании в текущего бойца
    {
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        gameObject.tag = "Finish";//меняем тэг чтобы убрать из массива целей
        //enabled = false;
        isDead = true;
        Destroy(gameObject);

    }
}
