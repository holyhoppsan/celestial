using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.0f, 100.0f)]
    float maxSpeed = 10.0f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        //playerInput.Normalize();
        //playerInput = Vector2.ClampMagnitude(playerInput, 1.0f);
        Vector3 acceleration = new Vector3(playerInput.x, 0.0f, playerInput.y) * maxSpeed;
        velocity += acceleration * Time.deltaTime;
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;
    }
}