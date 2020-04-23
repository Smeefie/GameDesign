using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderHealthplant : MonoBehaviour
{
    [Header("Animation" )]
    public Animator animator;

    [SerializeField] private Health health;
    [SerializeField] private KeyCode KeyCode;

    private System.Random rand;

    private void Start()
    {
        rand = new System.Random();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode))
        {
            if(animator.GetBool("inRange") && !animator.GetBool("dead"))
            {
                health.IncreaseHealth(rand.Next(25, 50));
                animator.SetBool("dead", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "playerObj")
        {
            animator.SetBool("inRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "playerObj")
        {
            animator.SetBool("inRange", false);
        }
    }
}
