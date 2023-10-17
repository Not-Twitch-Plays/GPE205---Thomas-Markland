using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tank : MonoBehaviour
{
    public int moveSpeed;
    public int accelSpeed;
    public int turnSpeed;
    public bool isStrafing;

    public GameObject bulletPrefab;
    public GameObject head;
    public GameObject body;

    Vector3 velocity;
    CharacterController cc;

    private void Update()
    {
        //Doing Movement
        velocity = Vector3.Lerp(velocity, Vector3.zero, 5 * Time.deltaTime);
        velocity.x = Mathf.Clamp(velocity.x, -moveSpeed, moveSpeed);
        velocity.y += Physics.gravity.y * 2 * Time.deltaTime;
        if (cc.isGrounded)
        {
            velocity.y = 0;
        }
        velocity.z = Mathf.Clamp(velocity.z, -moveSpeed, moveSpeed);

        cc.Move(transform.rotation * velocity * Time.deltaTime);
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Forward()
    {
        velocity.z += accelSpeed * Time.deltaTime;
    }

    public void Backward() 
    {
        velocity.z -= accelSpeed * Time.deltaTime;
    }

    public void Left()
    {
        if (isStrafing)
        {
            velocity.x -= accelSpeed * Time.deltaTime;
        }
        else
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
    }

    public void Right() 
    {
        if (isStrafing)
        {
            velocity.x += accelSpeed * Time.deltaTime;
        }
        else
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, head.transform.position + transform.forward, transform.rotation);
    }
}
