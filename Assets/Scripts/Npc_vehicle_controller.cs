using UnityEngine;

public class Npc_vehicle_controller : MonoBehaviour
{
    [SerializeField] private WheelCollider front_left_wheel;
    [SerializeField] private WheelCollider front_right_wheel;
    [SerializeField] private WheelCollider back_left_wheel;
    [SerializeField] private WheelCollider back_right_wheel;

    public Rigidbody vehicle_rb;
    public GameObject centerOfMassPosition;

    public float acceleration;
    public float breakingForce;
    public float maxTurnAngle;

    private float currentAcceleration;
    private float currentBreakingForce;
    private float currentTurnAngle;

    private void Start()
    {
        vehicle_rb.GetComponent<Rigidbody>().centerOfMass = centerOfMassPosition.transform.localPosition;
        Debug.Log(centerOfMassPosition.transform.localPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        Debug.Log(currentAcceleration);

        // apply break force if spacebar is held
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;

        } else
        {
            currentBreakingForce = 0f;
        }

        // apply acceleration to front wheels
        front_left_wheel.motorTorque = currentAcceleration;
        front_right_wheel.motorTorque = currentAcceleration;

        // apply current break force to all wheels
        front_left_wheel.brakeTorque = currentBreakingForce;
        front_right_wheel.brakeTorque = currentBreakingForce;
        back_left_wheel.brakeTorque = currentBreakingForce;
        back_right_wheel.brakeTorque = currentBreakingForce;

        // set current turning angle
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        front_left_wheel.steerAngle = currentTurnAngle;
        front_right_wheel.steerAngle = currentTurnAngle;
    }
}
