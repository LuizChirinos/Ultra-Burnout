using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGlassEntity : MonoBehaviour
{
    private Image glass;
    private float alpha;
    private Color color;
    private float alphaMultiplier = 4f;
    private ScreenGlassController controller;

    private void Start()
    {
        if (glass == null)
            glass = GetComponent<Image>();

        controller = GameObject.Find("GameController").GetComponent<ScreenGlassController>();
        alpha = 1f;
        color = glass.color;
    }
    private void OnEnable()
    {
        Start();
    }
    private void Update()
    {
        alpha -= Time.deltaTime / alphaMultiplier;
        color.a = alpha;
        glass.color = color;
        
        if (alpha <= 0f)
        {
            gameObject.SetActive(false);
            controller.hits--;
        }
    }
}
