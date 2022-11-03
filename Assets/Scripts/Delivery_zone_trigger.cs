using UnityEngine;

public class Delivery_zone_trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "npc_vehicle")
        {
            Debug.Log("Goods Delivered!");
        }
    }
}
