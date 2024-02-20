using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedrun : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to a UI Text element to display the timer
    private float startTime;
    private bool isRunning = false;

    private void Start()
    {
        // Make sure the timerText reference is set in the Inspector
        if (timerText == null)
        {
            Debug.LogError("Timer Text reference not set!");
            return;
        }

        // Initialize the timer when the player enters the scene
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerUI(elapsedTime);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimerUI(float time)
    {
        // Format the time as minutes:seconds
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timerText.text = $"Time: {minutes}:{seconds}";
    }
}
