
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Waypoint next;
    public bool check = false;
    private GameObject test2;
    private Transform current;
    // Start is called before the first frame update
    void Start()
    {
        GameObject test2 = GameObject.Find("Arrow1");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = target.transform.position;
        //targetPosition.y = transform.position.y;
        //GameObject.Find("Arrow1").transform.LookAt(target);
        if (check == true)
        {
            current= target; 
            Debug.Log("target is : " + current);
            GameObject.Find("Arrow").transform.LookAt(current);

            check = false;
        }
        
        //Debug.Log("target changed to :" + current);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = next.target;
        current = target;
        //GameObject.Find("Arrow").transform.LookAt(next.target);
        check = true;
       // Debug.Log("trigger enter " + other.transform.name);
        //Vehicle_controller hover = other.gameObject.GetComponent<Vehicle_controller>();
        
                //hover.target = next;
                //next.GetComponent<MeshRenderer>().material.color = Color.red;
                //GetComponent<MeshRenderer>().material.color = Color.white;
                //Debug.Log("next target is : " + next.target);
        
                //GameObject.Find("Arrow1").transform.LookAt(next.target);
           
    }
}