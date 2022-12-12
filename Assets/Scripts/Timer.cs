using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    private TimeSpan timePlaying;

    [Header("Audio Settings")]
    private AudioClip loseSound;
    private AudioSource audioSource;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    private void Awake()
    {
        loseSound = (AudioClip)Resources.Load("lose");
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (hasLimit && currentTime <= timerLimit)
        {
            currentTime = timerLimit;
            setTimerText();
            timerText.color = Color.black;
            enabled = false;
            StartCoroutine(PlaySound());
        }

        setTimerText();
    }

    private void setTimerText()
    {
        timePlaying = TimeSpan.FromSeconds(currentTime);
        timerText.text =  "Time " + timePlaying.ToString("mm':'ss':'ff");
    }

    IEnumerator PlaySound()
    {
        audioSource.clip = loseSound;
        audioSource.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }
}
