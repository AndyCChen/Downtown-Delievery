using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoint trackCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("checkpoint");
            trackCheckpoint.PlayerThroughCheckpoint(this);

        }
    }
    public void SetTrackCheckpoint(TrackCheckpoint trackCheckpoint)
    {
        this.trackCheckpoint = trackCheckpoint;
    }
}
