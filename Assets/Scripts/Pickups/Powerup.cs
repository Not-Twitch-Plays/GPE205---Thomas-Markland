using System.Collections.Generic;
using Unity;
using UnityEngine;

public abstract class Powerup
{
    public float duration;
    public bool isPermanent;
    public GameObject pickupEffect;

    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}