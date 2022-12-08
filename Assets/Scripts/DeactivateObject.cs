using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public GameObject deactivate_Object_Name_1;
    public GameObject deactivate_Object_Name_2;
    public GameObject activate_Object_Name_1;
    public GameObject activate_Object_Name_2;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deactivate_Object_Name_1.SetActive(false);
            deactivate_Object_Name_2.SetActive(false);
            activate_Object_Name_1.SetActive(true);
            activate_Object_Name_2.SetActive(true);
        }
    }
}
