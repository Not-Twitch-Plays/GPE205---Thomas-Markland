using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public int Damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().DoTakeDamage(Damage);
            //Only destroying if we hit something for now to support the bullet's bouncing the way I want them to
            Destroy(gameObject);
        }
    }
}
