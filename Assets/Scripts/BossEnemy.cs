using System.Collections;
using UnityEngine;

public class BossEnemy : Enemy
{
    public TankWeapon enemyWeapon;
    private float weaponCycleTime = 5.0f;

    private void Start()
    {
        maxHealth = 500; 
        currentHealth = maxHealth;
        StartCoroutine(CycleWeapons());
    }

    private IEnumerator CycleWeapons()
    {
        while (true)
        {
            yield return new WaitForSeconds(weaponCycleTime);
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        if (enemyWeapon.currentWeapon == TankWeapon.WeaponType.MachineGun)
        {
            enemyWeapon.SwitchWeapon(TankWeapon.WeaponType.Sniper);
        }
        else if (enemyWeapon.currentWeapon == TankWeapon.WeaponType.Sniper)
        {
            enemyWeapon.SwitchWeapon(TankWeapon.WeaponType.Shotgun);
        }
        else
        {
            enemyWeapon.SwitchWeapon(TankWeapon.WeaponType.MachineGun);
        }
    }
}
