using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMove : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private Vector2 movementVector;
    private float currentSpeed = 0;
    private float currentForewardDirection = 1;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
        {
            if (currentForewardDirection == -1)
                currentSpeed = 0;
            currentForewardDirection = 1;
        }  
        else if (movementVector.y < 0)
        {
            if (currentForewardDirection == 1)
                currentSpeed = 0;
            currentForewardDirection = -1;
        }
            
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += 70 * Time.deltaTime;
        }
        else
        {
            currentSpeed -= 50 * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, 10);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * 100 * Time.fixedDeltaTime));
    }
}