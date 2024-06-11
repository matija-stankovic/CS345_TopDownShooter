using System.Collections;
using UnityEngine;

public class BossEnemy : Enemy
{
    public TankWeapon enemyWeapon;
    private float weaponCycleTime = 5.0f;
    private int currentHealth;

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
        if (enemyWeapon.currentWeapon == EnemyWeapon.WeaponType.MachineGun)
        {
            enemyWeapon.SwitchWeapon(EnemyWeapon.WeaponType.Sniper);
        }
        else if (enemyWeapon.currentWeapon == EnemyWeapon.WeaponType.Sniper)
        {
            enemyWeapon.SwitchWeapon(EnemyWeapon.WeaponType.Shotgun);
        }
        else
        {
            enemyWeapon.SwitchWeapon(EnemyWeapon.WeaponType.MachineGun);
        }
    }
}
