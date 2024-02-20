using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float timer = 0f;
    private bool isTimerRunning = false;

    public Text timerText; // Reference to the UI Text element

    private void Start()
    {
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;

            // Update the UI Text element with the current timer value
            UpdateTimerText();
        }
    }

    private void OnDisable()
    {
        isTimerRunning = false;

        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player disabled. Time: " + timer + " seconds.");
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy disabled. Time: " + timer + " seconds.");
        }

        // Update the UI Text element with the final timer value when the object is disabled
        UpdateTimerText();
    }

    // Update the UI Text element with the current timer value
    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2") + " seconds"; // Format the time with two decimal places
        }
    }
}
