using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public virtual void Update()
    {
        //Just in case
    }
    public abstract void Shoot();
}
