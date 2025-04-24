using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 12;
    public HealthBar healthBar; // Assign this in the Unity Editor
    public YouDied YouDied; // Optional

    // This method applies damage to the current health
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth); // Update health bar only if assigned
        }
        else
        {
            Debug.LogWarning("HealthBar is not assigned!");
        }

        Debug.Log("Health Remaining: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle object destruction or death logic
    private void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); // Destroy the object

    }
}