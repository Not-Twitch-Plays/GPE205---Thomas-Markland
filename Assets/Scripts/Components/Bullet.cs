using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet : MonoBehaviour
{
    public int speed;

    public Controller myOwner;

    AudioSource sfx;

    Rigidbody rb;
    int bounces;

    Vector3 lastVel;
    Vector3 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
        //Initial velocity
        rb.AddForce(transform.forward * speed,ForceMode.VelocityChange);
    }
}
