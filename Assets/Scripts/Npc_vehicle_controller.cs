using System.Collections.Generic;
using UnityEngine;

public class Npc_vehicle_controller : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private GameObject vehicle_object;

    public Rigidbody vehicle_rb;
    public GameObject centerOfMassPosition;

    public float maxMotorTorque;
    public float maxBreakingTorque;
    public float maxTurnAngle;

    private float currentMotorTorque;
    private float currentBreakingTorque;
    private float currentTurnAngle;

    private Npc_vehicle_AI npc_vehicle_ai;

    private void Start()
    {
        vehicle_rb.centerOfMass = centerOfMassPosition.transform.localPosition;
        npc_vehicle_ai = vehicle_object.GetComponent<Npc_vehicle_AI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleVehicleBehavior();
        applyWheelForces();
    }

    private void handleVehicleBehavior()
    {
        if (npc_vehicle_ai.GetVehicleState() == Npc_vehicle_AI.VehicleStates.forward)
        {
            currentMotorTorque = maxMotorTorque;
            currentTurnAngle = 0.0f;
        }
        else if (npc_vehicle_ai.GetVehicleState() == Npc_vehicle_AI.VehicleStates.left)
        {
            currentTurnAngle = -maxTurnAngle;
        }
        else if (npc_vehicle_ai.GetVehicleState() == Npc_vehicle_AI.VehicleStates.right)
        {
            currentTurnAngle = maxTurnAngle;
        }
    }

    private void applyWheelForces()
    {
        // apply all acceleration, turn angles, and breaking forces to each axle
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.isSteering)
            {
                axleInfo.leftWheel.steerAngle = currentTurnAngle;
                axleInfo.rightWheel.steerAngle = currentTurnAngle;
            }
            if (axleInfo.isMotorized)
            {
                axleInfo.leftWheel.motorTorque = currentMotorTorque;
                axleInfo.rightWheel.motorTorque = currentMotorTorque;
            }

            applyWheelVisuals(axleInfo.leftWheel, axleInfo.leftTransform);
            applyWheelVisuals(axleInfo.rightWheel, axleInfo.rightTransform);
        }
    }

    private void applyWheelVisuals(WheelCollider collider, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftTransform;
    public Transform rightTransform;
    public bool isMotorized;
    public bool isSteering;
}
