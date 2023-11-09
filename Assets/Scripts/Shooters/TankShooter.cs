using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;

    public float RateOfFire;

    public Pawn myPawn;

    public AudioClip shootSound;

    float shootDelay;

    private void Start()
    {
        myPawn = GetComponent<Pawn>();
    }
    public override void Update()
    {
        base.Update();
        shootDelay -= Time.deltaTime;
    }
    public override void Shoot()
    {
        if (shootDelay <= 0)
        {
            if (bulletSpawn != null)
            {
                GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
                newBullet.GetComponent<Bullet>().myOwner = myPawn.myController;
                shootDelay = 1 / RateOfFire;
                myPawn.PlaySFX(shootSound);
            }
        }
    }
}
