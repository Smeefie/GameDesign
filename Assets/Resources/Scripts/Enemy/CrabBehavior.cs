using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehavior : MonoBehaviour
{
    public CircleCollider2D viewDistance;
    public AIPath aiPath;
    public Animator animator;

    [Header("temp stats")]
    [SerializeField]private int dmg = 5;
    private bool canAttack = true;
    private int attackCooldown = 3;

    private crabState state = crabState.idle;
    private enum crabState{
        idle,
        follow,
        attack
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case crabState.idle:
                aiPath.enabled = false;
                animator.SetBool("Follow", false);
                break;

            case crabState.follow:
                aiPath.enabled = true;
                animator.SetBool("Follow", true);
                break;

            case crabState.attack:
                break;

        }

        if (aiPath.reachedDestination)
        {
            state = crabState.attack;
        }
    }

    private IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "playerObj")
        {
            if (state == crabState.attack)
            {                      
                if (canAttack)
                {
                    collision.GetComponent<Health>().ReduceHealth(dmg);
                    StartCoroutine("cooldown");
                }                 
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerObj")
        {
            state = crabState.follow;
        }          
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "playerObj")
        {
            state = crabState.idle;
        }
    }
}
