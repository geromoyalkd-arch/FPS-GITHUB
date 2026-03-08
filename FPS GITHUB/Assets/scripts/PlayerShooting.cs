using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 50f;
    public float damage = 25f;
    public float fireRate = 0.2f;
    public Camera fpsCam;
    public MuzzleFlashEffect muzzleFlash;
    public GameObject impactEffect;
    public GameObject balaPrefab;
    public Transform puntoDisparo; 
    private float nextTimeToFire = 0f;
    private WeaponReload reload;
    public AudioSource audioDisparo;
    void Start()
    {
        if (fpsCam == null)
            fpsCam = Camera.main;
        reload = GetComponent<WeaponReload>();
    }

    
    
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (reload != null && !reload.CanShoot()) return;
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (audioDisparo != null)
            audioDisparo.PlayOneShot(audioDisparo.clip);
        reload.UseAmmo();
        if (balaPrefab != null && puntoDisparo != null)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, fpsCam.transform.rotation);
        }
        if (muzzleFlash != null)
            if (audioDisparo != null)
                audioDisparo.Play(); muzzleFlash.Flash();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,
                            fpsCam.transform.forward,
                            out hit, range))
        {
            if (impactEffect != null)
                Instantiate(impactEffect, hit.point,
                            Quaternion.LookRotation(hit.normal));

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }
}