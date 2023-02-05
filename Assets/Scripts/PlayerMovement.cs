using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f)]
    float maxSpeed = 10.0f;

    [SerializeField, Range(0.0f, 100.0f)]
    float maxAcceleration = 10.0f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        //playerInput.Normalize();
        //playerInput = Vector2.ClampMagnitude(playerInput, 1.0f);
        // Acceleration based movement
        // Vector3 acceleration = new Vector3(playerInput.x, 0.0f, playerInput.y) * maxSpeed;
        Vector3 desiredVelocity = new Vector3(playerInput.x, 0.0f, playerInput.y) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        if (velocity.x < desiredVelocity.x)
        {
            velocity.x = Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
        }
        else if (velocity.x > desiredVelocity.x)
        {
            velocity.x = Mathf.Max(velocity.x - maxSpeedChange, desiredVelocity.x);
        }

        if (velocity.z < desiredVelocity.z)
        {
            velocity.z = Mathf.Min(velocity.z + maxSpeedChange, desiredVelocity.z);
        }
        else if (velocity.z > desiredVelocity.z)
        {
            velocity.z = Mathf.Max(velocity.z - maxSpeedChange, desiredVelocity.z);
        }

        Vector3 displacement = velocity * Time.deltaTime;

        transform.localPosition += displacement;
    }
}