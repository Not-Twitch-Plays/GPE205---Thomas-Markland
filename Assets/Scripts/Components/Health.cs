using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool isDead;

    public GameObject deathExplosion;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int dmg, Controller dealer)
    {
        if (!isDead)
        {
            health -= dmg;
            health = Mathf.Clamp(health, 0, maxHealth);

            if (health <= 0)
            {
                isDead = true;
                DoDeath(dealer);
            }
        }
    }
    public void Heal(float amount)
    {
        if (!isDead)
        {
            health += amount;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }

    public void DoDeath(Controller killer)
    {
        GameObject deathParticle = Instantiate(deathExplosion,transform.position,Quaternion.identity);
        deathParticle.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX Volume");
        if(killer.GetComponent<PlayerController>() != null && GetComponent<AIController>() != null)
        {
            killer.GetComponent<PlayerController>().score += 100;
        }
        Destroy(gameObject);
    }
}
