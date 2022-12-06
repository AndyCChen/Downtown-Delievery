using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToNext : MonoBehaviour
{
    //public Car player;
    public float theta;
    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * 5;
        float delta = Mathf.Sin(theta);
        Vector3 direction = transform.position - GameObject.Find("Player").transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(-90, 0, 0);
        transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 1.6f, 0) + GameObject.Find("Player").transform.forward.normalized * 8 + Quaternion.LookRotation(direction, Vector3.up) * new Vector3(0, 0, delta);

    }
}
