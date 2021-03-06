﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChageSpeed : MonoBehaviour
{
    private float count;
    private float timeToChange = 10f;
    private float speedMultiplier = 1f;
    public delegate void OnWorldChangeSpeed(float amount);
    public OnWorldChangeSpeed onChangeSpeed = delegate { };
    [Range(0, 50)]
    public float timeScale = 1;
    
    void Start()
    {
        count = 0f;
        count = timeToChange;
        //WorldStatus.StopWorld();
        onChangeSpeed += WorldStatus.IncreaseWorldSpeed;
    }
    private void Update()
    {
        Time.timeScale = timeScale;

        count -= Time.deltaTime;
        if (count <= 0f && WorldStatus.worldSpeed >= 0.1f)
        {
            count = timeToChange;
            //Debug.Log("Velocity Increased by Time");
            onChangeSpeed(speedMultiplier);
        }
    }

}
