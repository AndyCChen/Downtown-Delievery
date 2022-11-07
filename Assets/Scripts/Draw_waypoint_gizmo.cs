using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_waypoint_gizmo : MonoBehaviour
{
    public Transform rootObject;

    private Waypoint_node[] waypointNodes;

    private void OnDrawGizmos()
    {
        if (rootObject == null) return;

        Gizmos.color = Color.red;

        // retrieve all waypoint nodes as a array
        waypointNodes = rootObject.GetComponentsInChildren<Waypoint_node>();

        // draw debug line from each waypoint node to all waypoint node neighbors
        foreach(Waypoint_node waypointNode in waypointNodes)
        {
            foreach (Waypoint_node neighborNode in waypointNode.waypoint_neighbors)
            {
                if (neighborNode != null)
                {
                    Gizmos.DrawLine(waypointNode.transform.position, neighborNode.transform.position);
                }
            }
        }
    }
}
