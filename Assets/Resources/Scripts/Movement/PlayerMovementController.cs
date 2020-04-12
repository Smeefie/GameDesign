using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    private float magnitude = 0;
    
    public float GetMagnitude()
    {
        return magnitude;
    }

    protected override void CheckForMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        magnitude = movement.magnitude;
    }
}
