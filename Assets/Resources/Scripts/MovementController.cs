using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{    
    public Rigidbody2D rb;

    private BaseStats baseStats;
    private float MovementSpeed;
    private float magnitude = 0;
    private Vector2 movement;

    private void Start()
    {
        baseStats = GetComponent<BaseStats>();
        MovementSpeed = baseStats.MovementSpeed;
    }

    void Update()
    {
        MovementSpeed = baseStats.MovementSpeed;
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
