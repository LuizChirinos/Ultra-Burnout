using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currentIndex += 1;
        currentIndex %= glasses.Length;
        glasses[currentIndex].SetActive(true);
    }

}
