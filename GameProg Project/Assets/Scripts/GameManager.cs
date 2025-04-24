using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character; // Reference to the player object
    [SerializeField] private Timer timerScript; // Reference to the Timer script
    [SerializeField] private YouDied youDiedScreen; // Reference to the YouDied screen

    private bool isGameOver = false; // To ensure game-over logic runs only once

    void Update()
    {
        // Check if the character is destroyed and trigger game over logic if not already triggered
        if (character == null && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    // Trigger game over logic when the character is destroyed
    private void TriggerGameOver()
    {
        isGameOver = true; // Prevent multiple calls to game-over logic

        // Stop the timer by disabling the Timer script
        timerScript.enabled = false;

        // Call the YouDied setup method to show the game-over screen
        youDiedScreen.Setup();

        // Pause the game (this will stop Time.deltaTime, and thus stop the Timer)
        Time.timeScale = 0;
    }
}
