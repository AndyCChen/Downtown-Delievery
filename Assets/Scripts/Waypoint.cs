
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform current;
    private GameObject arrow;

    public Waypoint next;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("Direction_arrow");
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Player")
        {
            target = next.target;
            current = target;
            arrow.GetComponent<DirectionalArrow>().SetTarget(current);
        }
    }
}