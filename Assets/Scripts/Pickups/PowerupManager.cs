using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;

    List<Powerup> powerupTrash;

    Pawn myPawn;


    private void Start()
    {
        powerups = new List<Powerup>();
        powerupTrash = new List<Powerup>();
        myPawn = GetComponent<Pawn>();
    }
    private void Update()
    {
        DecrementPowerupTimers();
    }
    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }
    public void Add(Powerup powerupToAdd)
    {
        // Apply the powerup to our tank
        powerupToAdd.Apply(this);
        // Save it to the main list
        powerups.Add(powerupToAdd);
        //if were the player, give the player 1000 points
        if (myPawn.myController.GetComponent<PlayerController>() != null)
        {
            myPawn.myController.GetComponent<PlayerController>().score += 1000;
        }
    }
    public void Remove(Powerup powerupToRemove)
    {
        // Remove the powerup from our tank
        powerupToRemove.Remove(this);
        // Add it to the trash
        powerupTrash.Add(powerupToRemove);
    }
    public void DecrementPowerupTimers()
    {
        // loop through all of our powerups
        foreach (Powerup powerup in powerups)
        {
            // Take any past time from the duration of the powerup
            powerup.duration -= Time.deltaTime;
            // Remove the powerup when it's time is up
            if (powerup.duration <= 0)
            {
                Remove(powerup);
            }
        }
    }
    private void ApplyRemovePowerupsQueue()
    {
        // Now that we are sure we are not iterating through "powerups", remove the powerups that are in the trash
        foreach (Powerup powerup in powerupTrash)
        {
            powerups.Remove(powerup);
        }
        // And reset our trash
        powerupTrash.Clear();
    }
}