using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(BaseStats), typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    void Start()
    {
        Initialize();
    }

    protected abstract void Initialize();
}
