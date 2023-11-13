using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    public GameObject pickupPrefab;
    public float spawnDelay;

    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;

    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }
    void Update()
    {
        // If we don't have a powerup, or our old one has been picked up
        if (spawnedPickup == null)
        {
            // And it is time to spawn one
            if (Time.time > nextSpawnTime)
            {
                // Spawn it and reset the Timer
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + Random.Range(spawnDelay / 2, spawnDelay * 2);
            }
        }
        else
        {
            // Otherwise, don't spawn a new one
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

}
