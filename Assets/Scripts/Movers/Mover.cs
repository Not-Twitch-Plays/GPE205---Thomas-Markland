using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public int moveSpeedMultiplier;
    public abstract void Start();
    public abstract void Move(Vector3 direction, float speed);
    public abstract void Rotate(float speed);
}