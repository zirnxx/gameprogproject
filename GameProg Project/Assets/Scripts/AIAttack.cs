using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float attackTime = 0.25f;
    private float timer = 0f;

    // AI-specific variables
    public Transform target; // Reference to the player
    public float attackRange = 2f; // Distance within which the enemy can attack
    public float attackCooldown = 1.5f; // Cooldown between attacks
    private float cooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject; // Fix for GameObject reference
        attackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Check if the target is within attack range
        if (target != null && Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            if (cooldownTimer >= attackCooldown)
            {
                PerformAttack();
                cooldownTimer = 0f; // Reset cooldown
            }
        }

        // Handle attack timing
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= attackTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(false);
            }
        }
    }

    private void PerformAttack()
    {
        attacking = true;
        attackArea.SetActive(true);
    }
}