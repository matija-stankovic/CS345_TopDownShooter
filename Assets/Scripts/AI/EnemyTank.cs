using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public EnemyTurret aimTurret;
    public EnemyMove move;
    public TankWeapon weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        if (move == null)
            move = GetComponentInChildren<EnemyMove>();
        if (aimTurret == null)
            aimTurret = GetComponentInChildren<EnemyTurret>();
        if (weapon == null)
            weapon = GetComponentInChildren<TankWeapon>();
    }

    public void HandleShoot()
    {
        weapon.Fire();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        move.Move(movementVector);
    }
    
    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);
        
    }

    public void HandleTurretTracking()
    {
        aimTurret.Tracking();
    }
}
