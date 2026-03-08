using UnityEngine;

public class WeaponReload : MonoBehaviour
{
    public int maxAmmo = 30;
    public int reserveAmmo = 90;
    public float reloadTime = 1.5f;

    private int currentAmmo;
    private bool isReloading = false;
    private float reloadTimer = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0f)
                FinishReload();
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reserveAmmo > 0)
            StartReload();

        if (currentAmmo <= 0 && reserveAmmo > 0)
            StartReload();
    }

    void StartReload()
    {
        isReloading = true;
        reloadTimer = reloadTime;
        Debug.Log("Recargando...");
    }

    void FinishReload()
    {
        int needed = maxAmmo - currentAmmo;
        int added = Mathf.Min(needed, reserveAmmo);
        currentAmmo += added;
        reserveAmmo -= added;
        isReloading = false;
        Debug.Log("Recarga completa! Balas: " + currentAmmo);
    }

    public bool CanShoot() => !isReloading && currentAmmo > 0;
    public void UseAmmo() { if (currentAmmo > 0) currentAmmo--; }
    public int GetCurrentAmmo() => currentAmmo;
    public int GetReserveAmmo() => reserveAmmo;
    public bool IsReloading() => isReloading;
}