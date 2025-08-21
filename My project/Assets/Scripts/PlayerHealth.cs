using UnityEngine;
using System; // Required to use the 'Action' type

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public int currentHealth;

    // 1. Declare the static event
    // 'Action' is a delegate that represents a function with no parameters.
    public static event Action OnPlayerDamaged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Don't take damage if already dead
        if (currentHealth <= 0) return;

        currentHealth -= amount;

        // 2. Invoke the event
        // The '?' checks if any scripts are listening before trying to call them.
        OnPlayerDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            //death screen
            Debug.Log("Player has died!");
        }
    }
}