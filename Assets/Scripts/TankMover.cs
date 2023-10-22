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
    }

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }

    public override void Rotate(float speed)
    {
        transform.Rotate(0,speed * Time.deltaTime,0);
    }
}