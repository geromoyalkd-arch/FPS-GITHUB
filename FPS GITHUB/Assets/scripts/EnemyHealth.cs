using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public AudioSource audioMuerte;
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Barra de vida")]
    public Slider healthBarSlider;
    public Transform healthBarCanvas;

    [Header("Efecto al morir")]
    public GameObject explosionPrefab;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBarSlider != null)
            healthBarSlider.value = 1f;

        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (healthBarCanvas != null && player != null)
        {
            healthBarCanvas.LookAt(player);
            healthBarCanvas.Rotate(0, 180, 0);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (healthBarSlider != null)
            healthBarSlider.value = currentHealth / maxHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (audioMuerte != null)
            AudioSource.PlayClipAtPoint(audioMuerte.clip, transform.position);

        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null) gm.EnemyKilled();

        Destroy(gameObject);
    }
}