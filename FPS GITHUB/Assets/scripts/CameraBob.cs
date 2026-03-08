using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public float velocidadBob = 10f;
    public float amplitudBob = 0.05f;

    private float timer = 0f;
    private Vector3 posicionOriginal;

    void Start()
    {
        posicionOriginal = transform.localPosition;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        if (Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputZ) > 0.1f)
        {
            timer += Time.deltaTime * velocidadBob;
            float bobY = Mathf.Sin(timer) * amplitudBob;
            float bobX = Mathf.Sin(timer / 2f) * amplitudBob * 0.5f;
            transform.localPosition = posicionOriginal + new Vector3(bobX, bobY, 0);
        }
        else
        {
            timer = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, posicionOriginal, Time.deltaTime * 5f);
        }
    }
}