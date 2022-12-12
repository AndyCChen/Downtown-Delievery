using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLevel : MonoBehaviour
{
    public int level;
    public void LastState()
    {
        level = PlayerPrefs.GetInt("SavedScene");
        if (level != 0)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            Debug.Log("too bad");
            return;
        }
    }
}
