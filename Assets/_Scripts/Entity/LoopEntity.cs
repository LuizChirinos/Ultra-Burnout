
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEntity : InteractableEntity
{
    private SpawnManager spawnManager;

    public override void Start()
    {
        base.Start();
        spawnManager = GameObject.Find("GameController").GetComponent<SpawnManager>();
    }

    public override void Update()
    {
        base.Update();
        if (this.transform.position.z < playerStatus.transform.position.z)
        {
            //interacted = true;
            //Invoke("InvokeInteraction", 1f);
            Interact();
        }
    }
    public override void Interact()
    {
        base.Interact();
        spawnManager.RespawnAt(this.transform, 1);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Destroyer"))
        {
            //Debug.Log("Interacted with Destroyer, " + gameObject.name);
            spawnManager.RespawnAt(this.transform, 1);
            Debug.Log("Respawn Entity " + gameObject.name);
        }
    }

    private void InvokeInteraction()
    {
        Interact();
        interacted = false;
    }
}
