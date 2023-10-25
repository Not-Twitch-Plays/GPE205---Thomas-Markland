using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode strafeLeft;
    public KeyCode strafeRight;
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public KeyCode shoot;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //Registering w/ GameManager
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
    }

    public override void Update()
    {
        base.Update();
        HandleInput();
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
    public void OnDestroy()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                // Deregister with the GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }
}