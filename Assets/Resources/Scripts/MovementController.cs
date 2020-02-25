using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MovementSpeed = 0.005f;
    public Rigidbody2D rb;

    private float magnitude = 0;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        magnitude = movement.magnitude;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }

    public float GetMagnitude()
    {
        return magnitude;
    }
}
