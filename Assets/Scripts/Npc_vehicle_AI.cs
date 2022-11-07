using UnityEngine;

public class Npc_vehicle_AI : MonoBehaviour
{
    [SerializeField] private Transform vehicle_transform;
    [SerializeField] private float rayCastDistance;

    public enum VehicleStates 
    {
        forward, 
        backward, 
        left,
        right
    };

    private VehicleStates vehicle_state;
    private bool isRayCollisionDetected;

    // Start is called before the first frame update
    void Start()
    {
        vehicle_state = VehicleStates.forward;
        isRayCollisionDetected =  false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        castVehicleRay();
    }

    private void castVehicleRay()
    {
        Vector3 forward = vehicle_transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(vehicle_transform.position, forward, rayCastDistance))
        {
            Debug.DrawRay(vehicle_transform.position, forward * ((int)rayCastDistance), Color.red);

            // choose to turn left or right randomly
            if (!isRayCollisionDetected)
            {
                int rand = (int)Random.Range(0, 2);
                vehicle_state = rand == 1 ? VehicleStates.left : VehicleStates.right;
            }

            isRayCollisionDetected = true;
        }
        else
        {
            isRayCollisionDetected = false;
            vehicle_state = VehicleStates.forward;
        }
    }

    public VehicleStates GetVehicleState()
    {
        return vehicle_state;
    }
}
