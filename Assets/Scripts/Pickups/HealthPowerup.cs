using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;
    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Heal the tank
            targetHealth.Heal(healthToAdd);
        }
    }

    public override void Remove(PowerupManager target)
    {
        
    }
}