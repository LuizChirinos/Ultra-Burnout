using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineGiverEntity : InteractableEntity
{
    #region Properties
    private PlayerStatus status;
    public int gasolineAmount = 10;
    private SoundController soundController;
    private SpawnManager spawnManager;

    #endregion

    public override void Start()
    {
        base.Start();
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        spawnManager = GameObject.Find("GameController").GetComponent<SpawnManager>();

}

#region Custom Methods
public override void Interact()
    {
        spawnManager.spawnedGas = false;
        soundController.Play(SoundController.Type.Gas);
        status.ChangeGasoline(gasolineAmount);
        base.Interact();
    }
    #endregion
}
