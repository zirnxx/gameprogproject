using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Health health = collider.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log("Applying damage to: " + collider.name);
            health.Damage(damage);
        }
        else
        {
            Debug.LogWarning("No Health component found on: " + collider.name);
        }
    }
}
