using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private TMP_Text timeCounter;

    private TimeSpan timePlaying;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        startTimer();
    }

    public void startTimer()
    {
        currentTime = startTime;

        StartCoroutine(UpdateTimer());
    }

    private void checkGameStatus()
    {
        // check if player has arrived at checkpoint
        Debug.Log("u lose, or win maybe");
    }

    private IEnumerator UpdateTimer()
    {
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(currentTime);
            string timerString = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timerString;

            yield return null;
        }

        checkGameStatus();
    }
}
