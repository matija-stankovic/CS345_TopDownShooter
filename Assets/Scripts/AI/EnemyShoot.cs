using UnityEngine;

public class EnemyShoot : CustomBehaviour
{
    public float vision = 300;

    public override void Action(EnemyTank tank, AIDetector detector)
    {
        if (targetVisible(tank, detector))
        {
            //tank.MoveEnemy(detector.Target.position);
            tank.HandleShoot();
        }
            
        tank.HandleTurretMovement(detector.Target.position);
    }
    private bool targetVisible(EnemyTank tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < vision / 2)
        {
            return true;
        }
        return false;
    }
}
