using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGlassController : MonoBehaviour
{
    public GameObject[] glasses;
    public int currentIndex = 0;
    public int hits;
    private int maxHits = 2;

    private void Start()
    {
        currentIndex = 0;
        foreach (GameObject glass in glasses)
        {
            glass.SetActive(false);
        }
    }
    private void Update()
    {
        if (hits >= maxHits)
        {
            WorldStatus.StopWorld(true);
        }
    }

    public void IncrementScreen()
    {
        glasses[currentIndex].SetActive(true);
        hits++;
        currentIndex += 1;
        currentIndex %= glasses.Length;
    }
}
