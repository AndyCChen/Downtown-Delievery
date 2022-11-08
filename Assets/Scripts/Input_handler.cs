using UnityEngine;

public class Input_handler : MonoBehaviour
{
    private Vehicle_controller vehicle_controller;

    private void Awake()
    {
        vehicle_controller = GetComponent<Vehicle_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        float accelerationInput = Input.GetAxis("Vertical");
        float steeringInput = Input.GetAxis("Horizontal");
        bool breakingInput = Input.GetKey(KeyCode.Space);

        vehicle_controller.SetInput(accelerationInput, steeringInput, breakingInput ? 1.0f : 0);
    }
}
