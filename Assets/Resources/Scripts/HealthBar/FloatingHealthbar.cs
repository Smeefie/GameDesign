using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FloatingHealthbar : Healthbar
{
    public Transform ToFollow;
    public float transitionSpeed = 1f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0.1f, 0);
    protected override BaseStats getBaseStats()
    {
        return GetComponentInParent<Canvas>().GetComponentInParent<BaseStats>();
    }

    protected override Health getHealth()
    {
        return GetComponentInParent<Canvas>().GetComponentInParent<Health>();
    }

    protected override Slider getSlider()
    {
        return gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        transform.position = ToFollow.position + offset;
        //Vector3 targetPosition = ToFollow.position + offset;
        //Vector3 Position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        //transform.position = Position;
    }
}
