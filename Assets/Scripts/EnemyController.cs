/*


/////////////////
///DISCLAIMER////
/////////////////

I'm aware that this AI is really stupid and is more like a braindead robot,
but it's just to see that it works lolz

                                

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Tank myTank;

    float turnTimer;
    float moveTimer;
    float shootTimer;
    bool doMoveFlip;
    bool doTurnFlip;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Turning AI
        turnTimer -= Time.deltaTime;
        if (turnTimer <= 0)
        {
            doTurnFlip = !doTurnFlip;
            turnTimer = Random.Range(1,5);
        }
        if (doTurnFlip)
        {
            myTank.Right();
        }
        else
        {
            myTank.Left();
        }

        //Moving AI
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 05)
        {
            doMoveFlip = !doMoveFlip;
            moveTimer = Random.Range(5, 10);
        }
        if (doMoveFlip)
        {
            myTank.Forward();
        }
        else
        {
            myTank.Backward();
        }

        //Shooting AI
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = Random.Range(3, 5);
            myTank.Shoot();
        }


    }
}
