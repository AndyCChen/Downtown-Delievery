using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    private int nextCheckPointIndex;
    private List<CheckpointSingle> checkpointSingleList;
    
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("CheckPoints");
        checkpointSingleList = new List<CheckpointSingle>();
        foreach(Transform checkpointSingleTransform in checkpointsTransform)
        {
            //Debug.Log(checkpointSingleTransform);
            CheckpointSingle checkpointSingle= checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoint(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckPointIndex = 0;
    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckPointIndex)
        {
            //correctCheckpoint
            Debug.Log("correct");
            nextCheckPointIndex++;
        }
        else
        {
            Debug.Log("wrong");

            //wrong checkpoint
        }
        //Debug.Log(checkpointSingle.transform.name);
    }
}
