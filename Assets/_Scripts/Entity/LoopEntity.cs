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
}
