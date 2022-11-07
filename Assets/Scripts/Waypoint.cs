using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Waypoint next;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter " + other.transform.name);
        Vehicle_controller hover = other.gameObject.GetComponent<Vehicle_controller>();
        if (hover != null)
        {
            if (hover.target == this)
            {
                hover.target = next;
                next.GetComponent<MeshRenderer>().material.color = Color.red;
                GetComponent<MeshRenderer>().material.color = Color.white;
                Debug.Log("next target!");
            }
            
        }
    }
}