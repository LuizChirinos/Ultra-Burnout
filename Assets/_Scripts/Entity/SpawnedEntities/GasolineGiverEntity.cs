using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineGiverEntity : InteractableEntity
{
    #region Properties
    private PlayerStatus status;
    public int gasolineAmount = 10;
    private SoundController soundController;

    #endregion

    public override void Start()
    {
        base.Start();
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>();
    }

    #region Custom Methods
    public override void Interact()
    {
        soundController.Play(SoundController.Type.Gas);
        status.ChangeGasoline(gasolineAmount);
        base.Interact();
    }
    #endregion
}
