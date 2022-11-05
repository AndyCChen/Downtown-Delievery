using System.Collections.Generic;
using UnityEngine;

public class Npc_vehicle_controller : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;

    public Rigidbody vehicle_rb;
    public GameObject centerOfMassPosition;

    public float maxMotorTorque;
    public float maxBreakingTorque;
    public float maxTurnAngle;

    private float currentMotorTorque;
    private float currentBreakingTorque;
    private float currentTurnAngle;

    private void Start()
    {
        vehicle_rb.GetComponent<Rigidbody>().centerOfMass = centerOfMassPosition.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentMotorTorque = maxMotorTorque * Input.GetAxis("Vertical");
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        // update current break force if spacebar is held
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingTorque = maxBreakingTorque;

        } else
        {
            currentBreakingTorque = 0f;
        }

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
