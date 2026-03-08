using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 50f;
    public float tiempoVida = 2f;

    private Vector3 direccion;

    void Start()
    {
        direccion = transform.forward;
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}