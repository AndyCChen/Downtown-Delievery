using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_vehicle_controller : MonoBehaviour
{
    [SerializeField] private Rigidbody vehicleObject;
    [SerializeField] private WheelCollider front_left_wheel;
    [SerializeField] private WheelCollider front_right_wheel;
    [SerializeField] private WheelCollider back_left_wheel;
    [SerializeField] private WheelCollider back_right_wheel;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // only be able to move if at least one wheel is touching the ground
        if (Input.GetAxisRaw("Vertical") > 0  && (front_left_wheel.isGrounded || front_right_wheel.isGrounded || back_left_wheel.isGrounded || back_right_wheel.isGrounded))
        {
            vehicleObject.AddRelativeForce(Vector3.forward * force);
        }
    }
}
