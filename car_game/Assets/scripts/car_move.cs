using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    public float driftFactor = 0.7f;
    public float carSpeed = 30f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityUp;

    Rigidbody2D rbCar;


    private void Awake()
    {
        rbCar = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {

        KillOrthogonalVelocity();

        ApplyEngineForce();

        ApplySteering();


    }

    void ApplyEngineForce()
    {
        velocityUp = Vector2.Dot(transform.up, rbCar.velocity);

        if (velocityUp > maxSpeed && accelerationInput > 0)
            return;

        if (velocityUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;

        if (rbCar.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        if (accelerationInput == 0)
        {
            rbCar.drag = Mathf.Lerp(rbCar.drag, 3.0f, Time.fixedDeltaTime);
        }
        else rbCar.drag = 0;


        Vector2 engineForceVector = transform.up * accelerationInput * carSpeed;

        rbCar.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedOnRotating = (rbCar.velocity.magnitude / 8);
        minSpeedOnRotating = Mathf.Clamp01(minSpeedOnRotating);

        rotationAngle -= steeringInput * turnFactor * minSpeedOnRotating;

        rbCar.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rbCar.velocity, transform.up);
        Vector2 rightelocity = transform.right * Vector2.Dot(rbCar.velocity, transform.right);

        rbCar.velocity = forwardVelocity + rightelocity * driftFactor;
    }

    float GetLateralVelosity()
    {
        return Vector2.Dot(transform.right, rbCar.velocity);
    }

    public bool IsTireScreeching(out float lateralVelosity, out bool isBraking)
    {
        lateralVelosity = GetLateralVelosity();
        isBraking = false;

        if (accelerationInput < 0 && velocityUp > 0)
        {
            isBraking = true;
            return true;
        }

        if (Mathf.Abs(GetLateralVelosity()) > 4.0f)
        {
            return true;
        }
        return false;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public float GetVelosityMagnitede()
    {
        return rbCar.velocity.magnitude;
    }

}

