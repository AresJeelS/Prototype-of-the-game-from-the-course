using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;
    public int Health = 1;
    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }
    public void Die()
    {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
}
