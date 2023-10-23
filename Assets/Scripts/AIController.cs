using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class AIController : Controller
{
    public float maxTargetDist;
    public float shootTargetDist;
    public float minTargetDist;

    public float patrolSpeed;
    public float chaseSpeed;


    public AIState currentState;
    private float lastStateChangeTime;
    public GameObject target;
    public GameObject[] Waypoints;

    int waypointIndex;

    public enum AIState 
    {
        //Making all the states we need
        Patrol, Chase, Shoot, Flee
    };

    public void Awake()
    {
        if (GetComponent<TankPawn>() != null)
        {
            myPawn = GetComponent<Pawn>();
        }
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //Makes sure that the waypointIndex is random on startup
        waypointIndex = Random.Range(0, Waypoints.Length - 1);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        MakeDecisions();
    }

    public void MakeDecisions()
    {
        if (target != null)
        {
            //promoting targetDistance toa variable
            float targetDistance = Mathf.Round(Vector3.Distance(myPawn.transform.position, target.transform.position));

            //If we're too far away, just patrol
            if (targetDistance >= maxTargetDist)
            {
                ChangeState(AIState.Patrol);
            }
            else
            {
                //If were in shooting distance, shoot. Otherwise, chase
                if (targetDistance <= shootTargetDist)
                {
                    ChangeState(AIState.Shoot);
                }
                else
                {
                    ChangeState(AIState.Chase);
                }

                //Personal space
                if (targetDistance <= minTargetDist)
                {
                    ChangeState(AIState.Flee);
                }
            }
        }
        else
        {
            //if we don't have a target yet, just patrol
            ChangeState(AIState.Patrol);

            //Try to find one
            if (GameManager.instance != null)
            {
                // And it tracks the player(s)
                if (GameManager.instance.players != null)
                {
                    // Deregister with the GameManager
                    target = GameManager.instance.players[0].myPawn.gameObject;
                }
            }
        }
        HandleInput();
    }
    public override void HandleInput()
    {
        switch (currentState)
        {
            case AIState.Patrol:
                DoPatrolState();
                break;
            case AIState.Shoot:
                DoShootState();
                break;
            case AIState.Chase:
                DoChaseState(target.transform.position);
                break;
            case AIState.Flee:
                DoFleeState(target.transform.position);
                break;
        }
    }

    protected void DoPatrolState()
    {
        myPawn.moveSpeed = patrolSpeed;
        //If we reach a waypoint, go to a new one
        if (Vector3.Distance(myPawn.transform.position, Waypoints[waypointIndex].transform.position) < 2)
        {
            waypointIndex = Random.Range(0, Waypoints.Length -1);
        }
        //Move towards the waypoint
        myPawn.RotateTowards(Waypoints[waypointIndex].transform.position);
        myPawn.MoveForward();
    }
    protected void DoShootState()
    {
        //Looks at target and shoots
        myPawn.RotateTowards(target.transform.position);
        myPawn.Shoot();
    }
    protected void DoChaseState(Vector3 targetPosition)
    {
        //Looks at target and moves forward
        myPawn.moveSpeed = chaseSpeed;
        myPawn.RotateTowards(target.transform.position);
        myPawn.MoveForward();
    }
    protected void DoFleeState(Vector3 targetPosition)
    {
        //Looks at target and moves back
        myPawn.moveSpeed = chaseSpeed;
        myPawn.RotateTowards(target.transform.position);
        myPawn.MoveBackward();
    }
    public virtual void ChangeState(AIState newState)
    {
        //Set the new state and update lastStateChangeTime
        currentState = newState;
        lastStateChangeTime = Time.time;

    }
}
