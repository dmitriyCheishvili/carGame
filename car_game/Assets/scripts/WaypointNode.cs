using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour
{

    public float maxSpeed = 0;

    [Header("This is the waypoint we are going towards nob yet reached")]
   public float minDistansToReachWaypoint = 5;

    public WaypointNode[] nextWaypointNode;
}
