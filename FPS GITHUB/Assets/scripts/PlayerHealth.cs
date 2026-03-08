using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Vida del jugador: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null)
            gm.GameOver();
    }

    public float GetHealthPercent() => currentHealth / maxHealth;
}