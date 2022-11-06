using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    public Waypoint target;
    
    private float horizontalInput;
    private float verticalInput;
    private float currentSteeringAngle;
    private float currentBreakForce;
    private bool isBraking;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;
    //references to wheel collider component
    [SerializeField] private WheelCollider FrontLeftWheel;
    [SerializeField] private WheelCollider FrontRightWheel;
    [SerializeField] private WheelCollider RearLeftWheel;
    [SerializeField] private WheelCollider RearRightWheel;

    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        //setting the input of breaking to spacebar
        isBraking = Input.GetKey(KeyCode.Space);

    }
    private void HandleMotor()
    {
        // apply force just to the front wheels
        FrontLeftWheel.motorTorque = verticalInput * motorForce;
        FrontRightWheel.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBraking ? breakForce : 0f;
        if (isBraking)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        FrontRightWheel.brakeTorque = currentBreakForce;
        FrontLeftWheel.brakeTorque = currentBreakForce;
        RearLeftWheel.brakeTorque = currentBreakForce;
        RearRightWheel.brakeTorque = currentBreakForce;
        isBraking = false;
    }
    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        FrontLeftWheel.steerAngle = currentSteeringAngle;
        FrontRightWheel.steerAngle = currentSteeringAngle;

    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftWheel, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheel, FrontRightWheelTransform);
        UpdateSingleWheel(RearLeftWheel, RearLeftWheelTransform);
        UpdateSingleWheel(RearRightWheel, RearRightWheelTransform);

    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
