using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(BaseStats), typeof(Rigidbody2D))]
[RequireComponent(typeof(ModuleSwapper), typeof(PlayerRenderer), typeof(PlayerMovementController))]
public abstract class PlayerClass : MonoBehaviour
{
}
