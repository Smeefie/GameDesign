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
    [SerializeField] private Text floatingText;
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
    }

    protected override void SetSlider(float amount)
    {
        StartCoroutine(FloatingNumbers((int)amount));
        base.SetSlider(amount);
    }

    IEnumerator FloatingNumbers(int amount)
    {
        var healthDifferential = (int) _currentHealth - (amount);
        var text = Instantiate(floatingText, this.transform);
        text.name = "FloatingNumbers";
        text.text = healthDifferential.ToString();
        if (healthDifferential < 0)
        {
            text.color = Color.green;
            healthDifferential *= -1;
        }
        while(text.color.a > 0)
        {
            yield return new WaitForSeconds(0.25f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.1f);
            text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + 0.02f);
        }

        Destroy(text.gameObject);
    }
}
