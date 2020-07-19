using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarEntitty : PointsGiverEntity
{
    #region Properties
    #endregion

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    #region Custom Methods
    public override void Interact()
    {
        base.Interact();
        //Explode carro
    }
    #endregion
}
