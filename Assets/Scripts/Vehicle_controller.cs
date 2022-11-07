using System.Collections.Generic;
using UnityEngine;

public class Vehicle_controller : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private GameObject vehicle_object;

    public Rigidbody vehicle_rb;
    public GameObject centerOfMassPosition;
    public Waypoint target;

    public float maxMotorTorque;
    public float maxBreakingTorque;
    public float maxTurnAngle;

    private float accelerationInput;
    private float steeringInput;
    private bool breakingInput;

    private float currentMotorTorque;
    private float currentBreakingTorque;
    private float currentTurnAngle;

    private void Start()
    {
        vehicle_rb.centerOfMass = centerOfMassPosition.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyWheelForces();
    }

    private void ApplyWheelForces()
    {
        currentMotorTorque = maxMotorTorque * accelerationInput;
        currentTurnAngle = maxTurnAngle * steeringInput;
        currentBreakingTorque = breakingInput ? maxBreakingTorque : 0;

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

            axleInfo.leftWheel.brakeTorque = currentBreakingTorque;
            axleInfo.rightWheel.brakeTorque = currentBreakingTorque;

            ApplyWheelVisuals(axleInfo.leftWheel, axleInfo.leftTransform);
            ApplyWheelVisuals(axleInfo.rightWheel, axleInfo.rightTransform);
        }
    }

    private void ApplyWheelVisuals(WheelCollider collider, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    public void SetInput(float accelInput, float steerInput, bool breakInput)
    {
        accelerationInput = accelInput;
        steeringInput = steerInput;
        breakingInput = breakInput;
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
