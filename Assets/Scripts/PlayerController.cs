using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode strafeLeft;
    public KeyCode strafeRight;
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public KeyCode shoot;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        HandleInput();

        base.Update();
    }

    public override void HandleInput()
    {
        if (Input.GetKey(moveForwardKey))
        {
            myPawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            myPawn.MoveBackward();
        }

        if (Input.GetKey(strafeLeft))
        {
            myPawn.StrafeLeft();
        }

        if (Input.GetKey(strafeRight))
        {
            myPawn.StrafeRight();
        }
        if (Input.GetKey(rotateLeft))
        {
            myPawn.RotateLeft();
        }

        if (Input.GetKey(rotateRight))
        {
            myPawn.RotateRight();
        }
        if (Input.GetKey(shoot))
        {
            myPawn.Shoot();
        }

    }
}