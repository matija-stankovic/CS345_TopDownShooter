using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed = 2f;
    public float rotationSpeed = 200f;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

   public void Move(Vector2 movementVector)
    {
        // Debug logging
        Debug.Log($"Movement vector: {movementVector}");

        // Calculate rotation angle with an additional 90 degrees rotation
        float targetAngle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
        targetAngle -= 90; // Apply extra 90 degrees rotation
        if (targetAngle < 0) targetAngle += 360; // Ensure angle is within [0, 360] range

        // Debug logging
        Debug.Log($"Target angle: {targetAngle}");

        // Smoothly rotate towards the target angle
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Apply movement
        Vector3 movement = new Vector3(movementVector.x, movementVector.y, 0) * movementSpeed * Time.deltaTime;
        transform.position += movement;
    }

}