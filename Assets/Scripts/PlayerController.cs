using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Tank myTank;

    float xInput;
    float yInput;

    private void Update()
    {
        //Setting up Input
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //Setting Strafe variable if we want to strafe
        myTank.isStrafing = Input.GetButton("Strafe");

        //Calling Movement Functions
        if (xInput > 0)
        {
            myTank.Right();
        }
        else
        {
            if (xInput < 0)
            {
                myTank.Left();
            }
        }
        if (yInput > 0)
        {
            myTank.Forward();
        }
        else
        {
            if (yInput < 0)
            {
                myTank.Backward();
            }
        }

        //Shooting if we want to shoot
        if(Input.GetButtonDown("Fire"))
        {
            myTank.Shoot();
        }
    }
}
