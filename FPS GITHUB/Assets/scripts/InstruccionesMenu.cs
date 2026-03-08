using UnityEngine;
using UnityEngine.SceneManagement;

public class InstruccionesMenu : MonoBehaviour
{
    public void JugarButton()
    {
        SceneManager.LoadScene(2); 
    }

    public void VolverButton()
    {
        SceneManager.LoadScene(0);
    }
}