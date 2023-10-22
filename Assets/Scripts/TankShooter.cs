using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float RateOfFire;

    float shootDelay;
    public override void Update()
    {
        base.Update();
        shootDelay -= Time.deltaTime;
    }
    public override void Shoot()
    {
        if (shootDelay <= 0)
        {
            Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
            shootDelay = 1 / RateOfFire;
        }
    }
}
