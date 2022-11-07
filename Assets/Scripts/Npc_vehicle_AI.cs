using UnityEngine;

public class Npc_vehicle_AI : MonoBehaviour
{
    public enum AIMode { chasePlayer, followWaypoint }

    [Header("Ai_mode")]
    public AIMode aiMode;

    // target position
    private Vector3 targetPosition = Vector3.zero;

    // target transform object
    private Transform targetTransform = null;

    private Vehicle_controller vehicle_controller;

    private void Awake()
    {
        vehicle_controller = GetComponent<Vehicle_controller>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (aiMode)
        {
            case AIMode.chasePlayer:
                FollowPlayer();
                break;
            case AIMode.followWaypoint:
                break;
        }

        float accelerationInput = 1.0f;
        float steeringInput = TurnToTarget();
        bool breakingInput = false;
        vehicle_controller.SetInput(accelerationInput, steeringInput, breakingInput);
    }

    void FollowPlayer()
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

    float TurnToTarget()
    {
        Vector3 position = transform.GetChild(0).position;

        // get vector that points to the target
        Vector3 vectorToTarget = targetPosition - position;
        vectorToTarget.Normalize();

        Vector3 forward = transform.GetChild(0).forward;
        Vector3 up = transform.GetChild(0).up;

        // get angle towards the target
        float angleToTarget = Vector3.SignedAngle(forward, vectorToTarget, up);
        //angleToTarget *= -1;
        
        float steerValue = angleToTarget / 45.0f;
        steerValue = Mathf.Clamp(steerValue ,-1.0f, 1.0f);
        Debug.Log(steerValue);
        return steerValue;
    }
}
