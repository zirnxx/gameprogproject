using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Don't forget to import TextMeshPro namespace!

public class YouDied : MonoBehaviour
{
    public TextMeshProUGUI pointText; // Change this to TextMeshProUGUI
    public TextMeshProUGUI longestTimeText; // Text to display the longest survival time
    public GameObject character; // Reference to the player object
    public Timer timerScript; // Reference to the Timer script
    public AudioSource gameOverAudio; // Reference to the AudioSource for the game over sound

    // Setup the "You Died" screen
    public void Setup()
    {
        gameObject.SetActive(true);

        // Play the game over sound if assigned
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }
        else
        {
            Debug.LogWarning("Game over audio not assigned in YouDied script.");
        }

        // Get the elapsed time from the Timer script at the moment of death
        string timeSurvived = timerScript.GetElapsedTime();
        pointText.text = "TIME SURVIVED: " + timeSurvived;

        // Compare and update the longest survival time
        float elapsedTime = timerScript.GetElapsedTimeInSeconds();
        float longestTime = PlayerPrefs.GetFloat("LongestSurvivalTime", 0);

        if (elapsedTime > longestTime)
        {
            PlayerPrefs.SetFloat("LongestSurvivalTime", elapsedTime);
            longestTime = elapsedTime; // Update the longest time to the new record
        }

        // Format the longest survival time for display
        int longestMinutes = Mathf.FloorToInt(longestTime / 60);
        int longestSeconds = Mathf.FloorToInt(longestTime % 60);
        longestTimeText.text = string.Format("BEST: {0:00}:{1:00}", longestMinutes, longestSeconds);
    }

    // Home button to go back to the home scene
    public void Home()
    {
        Time.timeScale = 1; // Resume time before navigating
        SceneManager.LoadScene("HomeScene");
    }

    // Restart button to restart the current scene
    public void Restart()
    {
        Time.timeScale = 1; // Resume time before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
