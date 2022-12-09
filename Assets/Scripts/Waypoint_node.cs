using UnityEngine;

public class Waypoint_node : MonoBehaviour
{
    public Waypoint_node[] waypoint_neighbors;
    public float minDistanceToWaypoint;
    public float minBreakingDistance;
    public float maxTurningVelocity;
}