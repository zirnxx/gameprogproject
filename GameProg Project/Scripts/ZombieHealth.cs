using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health = 3; // Set initial health

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject); // Destroy the zombie GameObject
    }
}
