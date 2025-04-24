using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player; // Reference to the player
    public float iShowSpeed; // Enemy's movement speed
    public Animator animator; // Animator for the enemy

    private float distance; // Distance between enemy and player
    private Vector2 lastDirection; // Tracks the last direction of movement

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance and direction to the player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Move the enemy toward the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, iShowSpeed * Time.deltaTime);

        // Update the animator with movement direction
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        // Save the last movement direction for idle animations
        if (direction.sqrMagnitude > 0.01f) // Small threshold to avoid jittering
        {
            lastDirection = direction;
        }

        // Set the idle animation direction when not moving
        if (direction.sqrMagnitude < 0.01f)
        {
            animator.SetFloat("IdleHorizontal", lastDirection.x);
            animator.SetFloat("IdleVertical", lastDirection.y);
        }
    }
}
