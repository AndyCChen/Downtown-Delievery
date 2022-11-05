using System.Collections.Generic;
using UnityEngine;

public class Vehicle_spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> vehiclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(vehiclePrefabs[((int)Random.Range(0.0f, 17.0f))], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
