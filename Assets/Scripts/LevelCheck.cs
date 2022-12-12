using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheck : MonoBehaviour
{
    public int level1;
    public void State()
    {
        level1 = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", level1);
        //SceneManager.LoadScene(0);
    }
}
