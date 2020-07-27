using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGlassController : MonoBehaviour
{
    public GameObject[] glasses;
    public int currentIndex = 0;

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
        glasses[currentIndex].SetActive(true);
        currentIndex += 1;
        currentIndex %= glasses.Length;
    }
}
