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
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(WeaponType.MachineGun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(WeaponType.Sniper);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(WeaponType.Shotgun);
        }
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


