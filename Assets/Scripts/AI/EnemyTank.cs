using System.Collections;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public EnemyTurret aimTurret;
    public EnemyMove move;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    private bool canShoot = true;
    
    void Start()
    {
        if (move == null)
            move = GetComponentInChildren<EnemyMove>();
        if (aimTurret == null)
            aimTurret = GetComponentInChildren<EnemyTurret>();
    }

    public void HandleShoot()
    {
        TryShoot(bulletSpawnPoint.up, 10, 10);
    }

    public void TryShoot(Vector3 direction, int damage, float speed)
    {
        if (canShoot)
        {
            StartCoroutine(ShootCoroutine(direction, damage, speed));
        }
    }

    private IEnumerator ShootCoroutine(Vector3 direction, int damage, float speed)
    {
        InstantiateBullet(direction, damage, speed);
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    private void InstantiateBullet(Vector3 direction, int damage, float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(direction, damage, speed);
    }


    public void MoveEnemy(Vector3 targetPosition)
    {
        Vector2 directionToTarget = (targetPosition - transform.position).normalized;
        move.Move(directionToTarget);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);
        
    }
}
