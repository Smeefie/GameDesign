﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Sprites")]
    public GameObject[] ModularSprites;

    [Header("Animation")]
    public Animator Animator;

    private PlayerMovementController playerMovementController;

    void Start()
    {
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        if(playerMovementController.GetMagnitude() != 0)
        {
            foreach (var module in ModularSprites)
            {
                module.GetComponent<Animator>().Play("Walking", -1);
                if(Input.GetAxis("Horizontal") != 0)
                    module.transform.localScale = new Vector3(-Mathf.Sign(Input.GetAxis("Horizontal")), 1f, 1f);
            }
        }
        else
        {
            foreach (var module in ModularSprites)
            {
                module.GetComponent<Animator>().Play("Idle", -1);
            }
        }
    }
}
