using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BaseStats))]
public abstract class MovementController : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float MovementSpeed;
    protected Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovementSpeed = GetComponent<BaseStats>().MovementSpeed;
    }

    void Update()
    {
        CheckForMovement();
    }

    void FixedUpdate()
    {
        Move();
    }

    protected abstract void CheckForMovement();

    protected void Move() //Make virtual if want to override
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }
}
