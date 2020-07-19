using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGiverEntity : InteractableEntity
{
    #region Properties
    private PlayerStatus status;
    public int scoreAmount = 10;
    #endregion

    public override void Start()
    {
        base.Start();
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

    }

    #region Custom Methods
    public override void Interact()
    {
        base.Interact();
        status.ChangeScore(scoreAmount);
    }
    #endregion
}
