using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rb;
    public override void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        moveSpeedMultiplier = 1;
    }

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.velocity = Vector3.Lerp(rb.velocity,direction.normalized * speed * moveSpeedMultiplier,10 * Time.deltaTime);
    }

    public override void Rotate(float speed)
    {
        transform.Rotate(0,speed * Time.deltaTime,0);
    }
}