using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class AIObjectCollision : MonoBehaviour
{
  
    [SerializeField] private List<GameObject> DeactivateObjectName;
    [SerializeField] private List<GameObject> ActivateObjectName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("AI_cars"))
        {
            int count;
           if (DeactivateObjectName.Count > ActivateObjectName.Count)
            {
                count= DeactivateObjectName.Count;
            }
           else
            {
                count= ActivateObjectName.Count;
            }
            for(int i = 0; i < count; i++)
            {
                if (DeactivateObjectName.Count > i)
                {
                    DeactivateObjectName[i].SetActive(false); ;
                }
                
                if (ActivateObjectName.Count > i)
                {
                    ActivateObjectName[i].SetActive(true);
                }
            }
            
          
        }
    }
}
