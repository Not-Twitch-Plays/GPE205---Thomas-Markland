using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public int Damage;

    public GameObject deathExplosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage,GetComponent<Bullet>().myOwner);
        }
        Die();
    }
    void Die()
    {
        GameObject deathParticle = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        deathParticle.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX Volume");
        Destroy(gameObject);
    }
}
