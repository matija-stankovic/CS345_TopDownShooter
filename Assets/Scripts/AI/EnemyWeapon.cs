using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Fire()
    {
        // WeaponSettings settings = machineGunSettings;
        // lastFireTime = Time.time;

        // if (currentWeapon == WeaponType.Shotgun)
        // {
        //     // Fire 3 bullets with spread
        //     for (int i = -1; i <= 1; i++)
        //     {
        //         Vector3 spreadDirection = Quaternion.Euler(0, 0, settings.bulletSpread * i) * bulletSpawnPoint.up;
        //         InstantiateBullet(spreadDirection, settings.damage, settings.bulletSpeed);
        //     }
        // }
        // else
        // {
        //     // Fire a single bullet
        //     InstantiateBullet(bulletSpawnPoint.up, settings.damage, settings.bulletSpeed);
        // }
    }
}
