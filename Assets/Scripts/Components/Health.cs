using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool isDead;

    public GameObject deathExplosion;

    private void Awake()
    {
        health = maxHealth;
    }

    public void DoTakeDamage(int dmg)
    {
        if (!isDead)
        {
            health -= dmg;
            health = Mathf.Clamp(health, 0, maxHealth);

            if (health == 0)
            {
                isDead = true;
                DoDeath();
            }
        }
    }

    public void DoDeath()
    {
        Instantiate(deathExplosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}