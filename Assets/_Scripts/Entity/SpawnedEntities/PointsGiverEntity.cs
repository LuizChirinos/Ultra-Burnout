using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGiverEntity : InteractableEntity
{
    #region Properties
    private PlayerStatus status;
    public int scoreAmount = 10;
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
        if (interacbleSound)
            soundController.Play(SoundController.Type.Coin);
        status.ChangeScore(scoreAmount);
        base.Interact();
    }
    #endregion
}
