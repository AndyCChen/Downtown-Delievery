
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform current;
    private GameObject arrow;
    public int levelCheck;
    public Waypoint next;

    // Start is called before the first frame update
    void Start()
    {
        levelCheck = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", levelCheck);
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