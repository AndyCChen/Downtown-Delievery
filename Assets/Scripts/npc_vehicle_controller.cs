using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_vehicle_controller : MonoBehaviour
{
    public float force;
    public Rigidbody vehicleObject;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            vehicleObject.AddForce(transform.forward * force);
            Debug.Log("yoo");
        }
    }
}