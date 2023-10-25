using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet : MonoBehaviour
{
    public int speed;
    public int maxBounces;

    public GameObject deathExplosion;


    Rigidbody rb;
    int bounces;

    Vector3 lastVel;
    Vector3 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //Initial velocity
        rb.velocity = transform.forward * speed;
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
            Destroy(collision.gameObject);
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
            }
        }
    }

    void Die()
    {
        Instantiate(deathExplosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
