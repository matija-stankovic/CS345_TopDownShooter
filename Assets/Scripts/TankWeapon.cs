using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    public enum WeaponType
    {
        MachineGun,
        Sniper,
        Shotgun
    }

    [System.Serializable]
    public class WeaponSettings
    {
        public float fireRate;
        public int damage;
        public float bulletSpread;  // Relevant for Shotgun
        public float bulletSpeed;
    }

    public WeaponType currentWeapon = WeaponType.MachineGun;
    public WeaponSettings machineGunSettings;
    public WeaponSettings sniperSettings;
    public WeaponSettings shotgunSettings;

    private float lastFireTime;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public GameObject machineGunSprite;
    public GameObject sniperSprite;
    public GameObject shotgunSprite;

    public GameObject machineGunFOV;
    public GameObject sniperFOV;
    public GameObject shotgunFOV;

    void Update()
    {
        HandleWeaponSwitch();
        if (Input.GetMouseButton(0) && Time.time > lastFireTime + GetCurrentSettings().fireRate && gameObject.tag == "Player")
        {
            Fire();
        }
    }

    WeaponSettings GetCurrentSettings()
    {
        switch (currentWeapon)
        {
            case WeaponType.MachineGun:
                return machineGunSettings;
            case WeaponType.Sniper:
                return sniperSettings;
            case WeaponType.Shotgun:
                return shotgunSettings;
            default:
                return null;
        }
    }

    public void Fire()
    {
        WeaponSettings settings = GetCurrentSettings();
        lastFireTime = Time.time;

        if (currentWeapon == WeaponType.Shotgun)
        {
            // Fire 3 bullets with spread
            for (int i = -1; i <= 1; i++)
            {
                Vector3 spreadDirection = Quaternion.Euler(0, 0, settings.bulletSpread * i) * bulletSpawnPoint.up;
                InstantiateBullet(spreadDirection, settings.damage, settings.bulletSpeed);
            }
        }
        else
        {
            // Fire a single bullet
            InstantiateBullet(bulletSpawnPoint.up, settings.damage, settings.bulletSpeed);
        }
    }

    public void InstantiateBullet(Vector3 direction, int damage, float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(direction, damage, speed);
    }

    public void SwitchWeapon(WeaponType newWeapon)
    {
        currentWeapon = newWeapon;
        lastFireTime = 0;
        UpdateWeaponSprite();
        UpdateWeaponFOV();
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.tag == "Player")
        {
            SwitchWeapon(WeaponType.MachineGun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.tag == "Player")
        {
            SwitchWeapon(WeaponType.Sniper);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.tag == "Player")
        {
            SwitchWeapon(WeaponType.Shotgun);
        }
    }

    void UpdateWeaponSprite()
    {
        if (machineGunSprite != null) machineGunSprite.SetActive(currentWeapon == WeaponType.MachineGun);
        if (sniperSprite != null) sniperSprite.SetActive(currentWeapon == WeaponType.Sniper);
        if (shotgunSprite != null) shotgunSprite.SetActive(currentWeapon == WeaponType.Shotgun);
    }

    void UpdateWeaponFOV()
    {
        if (machineGunFOV != null) machineGunFOV.SetActive(currentWeapon == WeaponType.MachineGun);
        if (sniperFOV != null) sniperFOV.SetActive(currentWeapon == WeaponType.Sniper);
        if (shotgunFOV != null) shotgunFOV.SetActive(currentWeapon == WeaponType.Shotgun);
    }

    public float getFireRate()
    {
        WeaponSettings settings = GetCurrentSettings();
        return settings.fireRate;
    }

    public float getLastFireTime()
    {
        return lastFireTime;
    }
}


