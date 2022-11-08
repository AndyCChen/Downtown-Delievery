using UnityEngine;
using System.Linq;

public class Npc_vehicle_AI : MonoBehaviour
{
    public enum AIMode { chasePlayer, followWaypoint }

    [Header("Ai_mode")]
    public AIMode aiMode;

    // target position and target transform object
    private Vector3 targetPosition = Vector3.zero;
    private Transform targetTransform = null;

    private Transform vehicleTransform;

    private Vehicle_controller vehicle_controller;

    private Waypoint_node currentWaypoint = null;
    private Waypoint_node[] allWaypoints;

    private void Awake()
    {
        vehicle_controller = GetComponent<Vehicle_controller>();
        allWaypoints = FindObjectsOfType<Waypoint_node>();
    }

    // Start is called before the first frame update
    private void Start()
    {
       vehicleTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (aiMode)
        {
            case AIMode.chasePlayer:
                FollowPlayer();
                break;
            case AIMode.followWaypoint:
                GoToWaypoint();
                break;
        }

        float accelerationInput = 1.0f;
        float steeringInput = TurnToTarget();
        bool breakingInput = false;
        vehicle_controller.SetInput(accelerationInput, steeringInput, breakingInput);
    }

    private void FollowPlayer()
    {
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
    }

    private void GoToWaypoint()
    {
        // select nearest waypoint to go to if currentWaypoint is null
        if (currentWaypoint == null)
        {
            currentWaypoint = GetClosestWaypoint();
        }

        if (currentWaypoint != null)
        {
            // set target position to be the waypoint
            targetPosition = currentWaypoint.transform.position;

            float distanceToWaypoint = Vector3.Distance(vehicleTransform.position, targetPosition);

            // if distance to waypoint is within minDistanceToWaypoint, travel to the next neighboring waypoint at random
            if (distanceToWaypoint <= currentWaypoint.minDistanceToWaypoint)
            {
                currentWaypoint = currentWaypoint.waypoint_neighbors[Random.Range(0, currentWaypoint.waypoint_neighbors.Length)];
            }
        }
    }

    private Waypoint_node GetClosestWaypoint()
    {
        return allWaypoints.OrderBy(node => Vector3.Distance(vehicleTransform.position, node.transform.position)).FirstOrDefault();
    }

    private float TurnToTarget()
    {
        // get vector that points to the target
        Vector3 vectorToTarget = targetPosition - vehicleTransform.position;
        vectorToTarget.Normalize();

        // get angle towards the target
        float angleToTarget = Vector3.SignedAngle(vehicleTransform.forward, vectorToTarget, vehicleTransform.up);
        
        float steerValue = angleToTarget / 45.0f;
        steerValue = Mathf.Clamp(steerValue , -1.0f, 1.0f);
        Debug.Log(steerValue);
        return steerValue;
    }
}
