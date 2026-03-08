using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad = 20f;
    public float tiempoVida = 3f;
    public float damage = 10f;

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

    void OnTriggerEnter(Collider other)
    {
        // Si golpea al jugador le hace daño
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(damage);

            Destroy(gameObject);
        }

        // Se destruye al golpear cualquier objeto menos el enemigo
        if (!other.CompareTag("Enemy") && !other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}