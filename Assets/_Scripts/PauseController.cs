using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pausePanel;
    public bool isPaused { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        WorldStatus.StopWorld(true);
        isPaused = true;
        pausePanel.SetActive(isPaused);
    }
    public void UnPause()
    {
        WorldStatus.StopWorld(false);
        isPaused = false;
        pausePanel.SetActive(isPaused);
    }
}
