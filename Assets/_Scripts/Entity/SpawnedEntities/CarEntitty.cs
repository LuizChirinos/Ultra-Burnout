using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarEntitty : PointsGiverEntity
{
    #region Properties
    private PlayerStatus status;
    private ScreenGlassController screenGlassController;
    public GameObject explosionPrefab;
    //private StressReceiver camShake;
    #endregion

    public override void Start()
    {
        base.Start();
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        //camShake = Camera.main.GetComponent<StressReceiver>();
        screenGlassController = GameObject.Find("GameController").GetComponent<ScreenGlassController>();
    }

    public override void Update()
    {
        base.Update();
    }

    #region Custom Methods
    public override void Interact()
    {
        //Shakes Camera
        StressReceiver.InduceStress(1f);
        //Instantiate Explosion
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //Increase World Speed
        WorldStatus.IncreaseWorldSpeed(1f);

        base.Interact();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    #endregion
}
