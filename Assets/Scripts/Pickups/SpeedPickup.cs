using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    public SpeedPowerup powerup;
    public void OnTriggerEnter(Collider other)
    {
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            // Add the powerup
            powerupManager.Add(powerup);

            // Destroy this pickup and spawn the effect for it
            GameObject powerupParticle = Instantiate(powerup.pickupEffect, transform.position, Quaternion.identity);
            powerupParticle.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX Volume");
            Destroy(gameObject);
        }
    }
}
