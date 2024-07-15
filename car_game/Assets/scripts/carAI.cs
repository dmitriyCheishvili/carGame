using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class carAI : MonoBehaviour
{
    car_move carMove;

    public enum AIMode {followPlayer, followWaypoint};
    public float maxSpeed = 16;

    public AIMode aiMode;
    public float MaxSpeed = 16;

    Vector3 targetPosition = Vector3.zero;

    Transform targetTransform = null;

    WaypointNode currentWaypoint = null;
    WaypointNode[] allWaypoint;

    private void Awake()
    {
        carMove = GetComponent<car_move>();
        allWaypoint = FindObjectsOfType<WaypointNode>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;

        switch (aiMode)
        {
            case AIMode.followPlayer:
                followPlayer();
                break;

                case AIMode.followWaypoint:
                followWaypoint();
                break;
        }

        inputVector.x = TurnTowardTarget();
        inputVector.y = ApplyThottleOrBrake(inputVector.x);

        carMove.SetInputVector(inputVector);
    }
    
    void followPlayer()
    {
        if (targetTransform == null)
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
      
    }

    void followWaypoint()
    {
        if (currentWaypoint == null)
            currentWaypoint = FindClosestWayPoint();

        if (currentWaypoint != null)
        {
            targetPosition = currentWaypoint.transform.position;

            float distanceToWayPoint = (targetPosition - transform.position).magnitude;

            if (distanceToWayPoint <= currentWaypoint.minDistansToReachWaypoint)
            {
                if (currentWaypoint.maxSpeed > 0)
                {
                    maxSpeed = currentWaypoint.maxSpeed;
                }
                else maxSpeed = 1000;


                currentWaypoint = currentWaypoint.nextWaypointNode[Random.Range(0, currentWaypoint.nextWaypointNode.Length)];
            }
        }
    }

    WaypointNode FindClosestWayPoint()
    {
        return allWaypoint
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
            .FirstOrDefault();
    }


    float TurnTowardTarget()
    {
        Vector2 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();

        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
        angleToTarget *= -1;

        float steerAmount = angleToTarget / 45.0f;

        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);

        return steerAmount;
    }

    float ApplyThottleOrBrake(float inputX)
    {
        if (carMove.GetVelosityMagnitede() > maxSpeed)
        {
            return 0;
        }

        return 1.05f - Mathf.Abs(inputX) / 1.0f;

    }

}
