using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f)]
    float maxSpeed = 10.0f;

    [SerializeField, Range(0.0f, 100.0f)]
    float maxAcceleration = 10.0f;

    [SerializeField]
    Rect allowedArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);

    [SerializeField, Range(0.0f, 1.0f)]
    float bounciness = 0.5f;

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

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        // if (velocity.x < desiredVelocity.x)
        // {
        //     velocity.x = Mathf.Min(velocity.x + maxSpeedChange, desiredVelocity.x);
        // }
        // else if (velocity.x > desiredVelocity.x)
        // {
        //     velocity.x = Mathf.Max(velocity.x - maxSpeedChange, desiredVelocity.x);
        // }

        // if (velocity.z < desiredVelocity.z)
        // {
        //     velocity.z = Mathf.Min(velocity.z + maxSpeedChange, desiredVelocity.z);
        // }
        // else if (velocity.z > desiredVelocity.z)
        // {
        //     velocity.z = Mathf.Max(velocity.z - maxSpeedChange, desiredVelocity.z);
        // }

        Vector3 displacement = velocity * Time.deltaTime;

        Vector3 newPosition = transform.localPosition + displacement;
        if (!allowedArea.Contains(new Vector2(newPosition.x, newPosition.z)))
        {
            // newPosition.x = Mathf.Clamp(newPosition.x, allowedArea.xMin, allowedArea.xMax);
            // newPosition.z = Mathf.Clamp(newPosition.z, allowedArea.yMin, allowedArea.yMax);
            if (newPosition.x < allowedArea.xMin)
            {
                newPosition.x = allowedArea.xMin;
                velocity.x = -velocity.x * bounciness;
            }
            else if (newPosition.x > allowedArea.xMax)
            {
                newPosition.x = allowedArea.xMax;
                velocity.x = -velocity.x * bounciness;
            }

            if (newPosition.z < allowedArea.yMin)
            {
                newPosition.z = allowedArea.yMin;
                velocity.z = -velocity.z * bounciness;
            }
            else if (newPosition.z > allowedArea.xMax)
            {
                newPosition.z = allowedArea.xMax;
                velocity.z = -velocity.z * bounciness;
            }
        }
        transform.localPosition = newPosition;
    }
}