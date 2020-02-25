using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int MovementSpeed = 2;
    public Animator animator;

    private float magnitude = 0;

    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        magnitude = Movement.magnitude;

        transform.Translate(Movement.x * Time.deltaTime, Movement.y * Time.deltaTime, 0.0f);
    }

    public float GetMagnitude()
    {
        return magnitude;
    }
}
