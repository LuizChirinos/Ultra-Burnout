﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : InteractableEntity
{
    private PlayerStatus status;
    private float amountToLose = 30f;
    private ScreenGlassController screenGlassController;
    //private StressReceiver camShake;

    public override void Start()
    {
        base.Start();

        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        screenGlassController = GameObject.Find("GameController").GetComponent<ScreenGlassController>();
        //camShake = Camera.main.GetComponent<StressReceiver>();
    }

    public override void Interact()
    {
        base.Interact();
        status.ChangeGasoline(-amountToLose);
        screenGlassController.IncrementScreen();
        StressReceiver.InduceStress(3f);
        WorldStatus.DecreaseWorldSpeed(1f);
    }
}
