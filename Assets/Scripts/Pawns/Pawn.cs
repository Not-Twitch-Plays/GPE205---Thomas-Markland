using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public Mover myMover;
    public Shooter myShooter;
    public Rigidbody rb;
    public Controller myController;

    // Start is called before the first frame update
    public virtual void Start()
    {
        myMover = GetComponent<Mover>();
        myShooter = GetComponent<Shooter>();
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Update()
    {
        //Just in case
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void StrafeLeft();
    public abstract void StrafeRight();
    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void PlaySFX(AudioClip clip);
}