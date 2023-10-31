using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TankPawn : Pawn
{
    public GameObject body;
    public Slider healthBar;

    Health myHealth;

    public override void Start()
    {
        base.Start();
        myHealth = GetComponent<Health>();
    }

    public override void Update()
    {
        base.Update();
        if (body != null)
        {
            if (Mathf.Round(rb.velocity.magnitude * 10) / 10 != 0)
            {

                Quaternion toRotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
                body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, toRotation, 360 * Time.deltaTime);
            }

        }
        if (healthBar != null)
        {
            healthBar.value = myHealth.health;
            healthBar.maxValue = myHealth.maxHealth;
        }
    }

    public override void MoveForward()
    {
        myMover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        myMover.Move(transform.forward, -moveSpeed);
    }

    public override void StrafeLeft()
    {
        myMover.Move(transform.right, -moveSpeed);
    }

    public override void StrafeRight()
    {
        myMover.Move(transform.right, moveSpeed);
    }
    public override void RotateLeft()
    {
        myMover.Rotate(-turnSpeed);
    }

    public override void RotateRight()
    {
        myMover.Rotate(turnSpeed);
    }
    public override void Shoot()
    {
        myShooter.Shoot();
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        //Getting our math together
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        //Starts Rotating
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}