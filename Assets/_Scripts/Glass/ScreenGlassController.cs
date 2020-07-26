using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGlassController : MonoBehaviour
{
    public GameObject[] glasses;
    public int currentIndex = 0;
    public float alpha;
    public float delayToDisappear = 3f;
    public Color color;

    private void Start()
    {
        currentIndex = 0;
        foreach (GameObject glass in glasses)
        {
            glass.SetActive(false);
        }
    }

    public void IncrementScreen()
    {
        color = Color.white;
        alpha = 1f;
        color.a = alpha;
        glasses[currentIndex].GetComponent<Image>().color = color;

        glasses[currentIndex].SetActive(true);
        color = glasses[currentIndex].GetComponent<Image>().color;
        alpha = color.a;
        currentIndex += 1;
        currentIndex %= glasses.Length;
    }
}
