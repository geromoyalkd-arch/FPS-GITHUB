using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI killText;
    public Slider healthBar;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public int totalEnemies = 4;

    private int killCount = 0;
    private WeaponReload reload;
    private PlayerHealth pHealth;

    void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
        {
            reload = p.GetComponent<WeaponReload>();
            pHealth = p.GetComponent<PlayerHealth>();
        }
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
    }

    void Update()
    {
        if (reload != null && ammoText != null)
        {
            if (reload.IsReloading())
                ammoText.text = "RECARGANDO...";
            else
                ammoText.text = reload.GetCurrentAmmo() + " / " + reload.GetReserveAmmo();
        }

        if (pHealth != null && healthBar != null)
            healthBar.value = pHealth.GetHealthPercent();

        if (killText != null)
            killText.text = "Kills: " + killCount + "/" + totalEnemies;
    }

    public void EnemyKilled()
    {
        killCount++;
        if (killCount >= totalEnemies)
            Win();
    }

    public void GameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Win()
    {
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}