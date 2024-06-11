using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public float turretRotationSpeed = 150;
    public GameObject target;
    [SerializeField]
    public Transform turretFollow;

    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDirection = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
    }

    public void Tracking()
    {
        var targetPosition = target.transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetPosition - turretFollow.transform.position, turretFollow.transform.TransformDirection(-Vector3.forward));
        turretFollow.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
