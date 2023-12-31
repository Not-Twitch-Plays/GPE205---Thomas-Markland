using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn myPawn;

    public virtual void Start()
    {
        //Just in case
    }
    public virtual void Update()
    {
        //Just in case
        if (myPawn.myController != this)
        {
            myPawn.myController = this;
        }
    }

    public abstract void HandleInput();
}