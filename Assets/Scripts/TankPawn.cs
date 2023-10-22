using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
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
}