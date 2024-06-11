using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private CustomBehaviour shoot, patrol;
    
    [SerializeField]
    private EnemyTank tank;

    [SerializeField]
    private AIDetector detector;
    void Start()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<EnemyTank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detector.TargetVisible) {
            if (Time.time > tank.weapon.getLastFireTime() + tank.weapon.getFireRate())
            {
                shoot.Action(tank, detector);
            }         
        }
        else {
            patrol.Action(tank, detector);
        }
        
    }
}
