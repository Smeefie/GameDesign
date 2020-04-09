using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FloatingHealthbar : Healthbar
{
    public Transform ToFollow;
    [SerializeField] private Vector3 offset = new Vector3(0, 0.2f, 0);
    protected override BaseStats getBaseStats()
    {
        return ToFollow.gameObject.GetComponent<BaseStats>();
    }

    protected override Health getHealth()
    {
        return ToFollow.gameObject.GetComponent<Health>();
    }

    protected override Text getHealthDisplayText()
    {
        return gameObject.GetComponentInChildren<Text>();
    }

    protected override Slider getSlider()
    {
        return gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        gameObject.transform.position = ToFollow.gameObject.transform.position + offset;
    }
}
