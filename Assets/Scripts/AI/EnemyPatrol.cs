using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : CustomBehaviour
{
    [SerializeField]
    private Vector2 direction = Vector2.zero;
    [SerializeField]
    private float tempPatrolDelay;
    public float patrolDelay = 4;


    public override void Action(EnemyTank tank, AIDetector detector)
    {
        float angle = Vector2.Angle(tank.aimTurret.transform.right, direction);
        if (tempPatrolDelay <= 0 && (angle < 2))
        {
            direction = Random.insideUnitCircle;
            tempPatrolDelay = patrolDelay;
        }
        else
        {
            if (tempPatrolDelay > 0)
                tempPatrolDelay -= Time.deltaTime;
            else
                tank.HandleTurretMovement((Vector2)tank.aimTurret.transform.position + direction);
                //tank.HandleTurretTracking();
        }

    }

    public void Awake(){
        direction = Random.insideUnitCircle;
    }
}
