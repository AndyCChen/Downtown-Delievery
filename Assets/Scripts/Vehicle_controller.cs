using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Vehicle_controller : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;

    public Rigidbody vehicle_rb;
    public GameObject centerOfMassPosition;
    public Waypoint target;

    public float maxMotorTorque;
    public float maxBreakingTorque;
    public float maxTurnAngle;

    private float accelerationInput;
    private float steeringInput;
    private float breakingInput;

    private float currentMotorTorque;
    private float currentBreakingTorque;
    private float currentTurnAngle;

    private AudioClip crashSound;
    private AudioSource audioSource;

    private void Awake()
    {
        crashSound = (AudioClip)Resources.Load("crash");
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        vehicle_rb.centerOfMass = centerOfMassPosition.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
        ApplyWheelForces();
    }

    private void ApplyWheelForces()
    {
        currentMotorTorque = maxMotorTorque * accelerationInput;
        currentTurnAngle = maxTurnAngle * steeringInput;
        currentBreakingTorque = breakingInput * maxBreakingTorque;

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

    public void SetInput(float accelInput, float steerInput, float breakInput)
    {
        accelerationInput = accelInput;
        steeringInput = steerInput;
        breakingInput = breakInput;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = crashSound;
        audioSource.Play();
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
