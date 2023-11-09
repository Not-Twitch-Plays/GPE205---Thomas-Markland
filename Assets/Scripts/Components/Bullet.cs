using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet : MonoBehaviour
{
    public int speed;
    public int maxBounces;

    public GameObject deathExplosion;

    public AudioClip hitSound;

    public Controller myOwner;

    AudioSource sfx;

    Rigidbody rb;
    int bounces;

    Vector3 lastVel;
    Vector3 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //Initial velocity
        rb.velocity = transform.forward * speed;
        sfx = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        //Getting last velocity for bouncing code
        lastVel = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //We hit another bullet!
            Die();
        }
        else
        {
            //If we made it this far and we haven't been destroyed yet, we are probably
            //bouncing off of a wall :)

            bounces++;
            if (bounces > maxBounces)
            {
                //Too many bounces. I'm dead X(
                Die();
            }
            else
            {
                //Bounce off dat wall homie :)
                dir = Vector3.Reflect(lastVel.normalized, collision.contacts[0].normal);
                rb.velocity = dir * speed;
                sfx.PlayOneShot(hitSound, PlayerPrefs.GetFloat("SFX Volume"));
            }
        }
    }

    void Die()
    {
        GameObject deathParticle = Instantiate(deathExplosion,transform.position,Quaternion.identity);
        deathParticle.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX Volume");
        Destroy(gameObject);
    }
}
