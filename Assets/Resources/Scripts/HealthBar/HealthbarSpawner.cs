using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarSpawner : MonoBehaviour
{
    [SerializeField] private FloatingHealthbar Prototype;

    void Start()
    {
        var canvas = gameObject.GetComponent<Canvas>();
        var healthbar = Instantiate(Prototype, canvas.transform);
        healthbar.ToFollow = GetComponentInParent<Transform>();
    }
}
