using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    public override void Apply(PowerupManager target)
    {
        Mover targetMover = target.GetComponent<Mover>();
        if (targetMover != null)
        {
            //Add Speed Boost
            targetMover.moveSpeedMultiplier = 2;
        }
    }

    public override void Remove(PowerupManager target)
    {
        Mover targetMover = target.GetComponent<Mover>();
        if (targetMover != null)
        {
            //Add Speed Boost
            targetMover.moveSpeedMultiplier = 1;
        }
    }
}