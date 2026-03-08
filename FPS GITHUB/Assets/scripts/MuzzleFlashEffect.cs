using UnityEngine;

public class MuzzleFlashEffect : MonoBehaviour
{
    public Light muzzleLight;
    public float flashDuration = 0.1f;
    public float flashIntensity = 10f;

    private float flashTimer = 0f;

    void Start()
    {
        if (muzzleLight != null)
        {
            muzzleLight.enabled = true;
            muzzleLight.intensity = 0f;
        }
    }

    void Update()
    {
        if (flashTimer > 0f)
        {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0f)
            {
                flashTimer = 0f;
                if (muzzleLight != null)
                    muzzleLight.intensity = 0f;
            }
        }
    }

    public void Flash()
    {
        if (muzzleLight != null)
        {
            muzzleLight.enabled = true;
            muzzleLight.intensity = flashIntensity;
            flashTimer = flashDuration;
        }
    }
}