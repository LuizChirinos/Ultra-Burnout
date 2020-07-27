using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : InteractableEntity
{
    private PlayerStatus status;
    private float amountToLose = 30f;
    private ScreenGlassController screenGlassController;
    private SoundController soundController;
    private Rigidbody rb;

    public float amountSpeedToIncrease = 1f;
    //private StressReceiver camShake;

    public override void Start()
    {
        base.Start();

        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        screenGlassController = GameObject.Find("GameController").GetComponent<ScreenGlassController>();
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        rb = GetComponent<Rigidbody>();
        //camShake = Camera.main.GetComponent<StressReceiver>();
    }

    public override void Interact()
    {
        //base.Interact();
        if (CanInteract())
        {
            interacted = true;
            //status.ChangeGasoline(-amountToLose);
            screenGlassController.IncrementScreen();
            StressReceiver.InduceStress(3f);
            //-WorldStatus.DecreaseWorldSpeed(-1f);
            soundController.Play(SoundController.Type.Obstacle);
            rb.freezeRotation = false; 
            Debug.Log("Colidiu com o cone");
        }
    }


    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseSpeed(amountSpeedToIncrease);
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Enemy"))
        {
            IncreaseSpeed(amountSpeedToIncrease);
        }
    }
}
