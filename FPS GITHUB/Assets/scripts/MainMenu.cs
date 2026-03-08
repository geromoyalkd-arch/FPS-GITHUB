using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject controlsPanel;

    void Start()
    {
       
        if (controlsPanel != null)
            controlsPanel.SetActive(false);
    }

    public void JugarButton()
    {
        SceneManager.LoadScene(1); 
    }

    public void ControlesButton()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(true);
    }

    public void CerrarControles()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(false);
    }

    public void SalirButton()
    {
        Application.Quit();
    }
}