using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : CustomBehaviour
{
    public float vision = 60;

    public override void Action(EnemyTank tank, AIDetector detector)
    {
        if (targetVisible(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }

        //tank.HandleTurretMovement(detector.Target.position);
        tank.HandleTurretTracking();
    }

    private bool targetVisible(EnemyTank tank, AIDetector detector)
    {
        /*
        //var direction = detector.Target.position - tank.aimTurret.transform.position;
        var direction = tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < vision / 2) // < vision / 2
        {
            return true;
        }
        return false;
        */
        return detector.TargetVisible;
    }
}
