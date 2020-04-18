using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts.Player.Abilities.Buffs;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private List<string> Targets;
    public bool DestroyOnContact;
    [SerializeField] private Vector2 Movement;

    private Buff EffectPrototype;

    //TODO: add sprite and animation
    private Rigidbody2D rb;
    private Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!Targets.Contains(col.gameObject.tag)) return;

        var effect = col.gameObject.AddComponent<Buff>();
        effect = EffectPrototype;

        if (DestroyOnContact) Destroy(gameObject);
    }

    void Update()
    {
        rb.MovePosition(Movement * Time.deltaTime);
    }
}
