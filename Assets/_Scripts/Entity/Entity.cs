using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour
{
    public bool isStatic = false;
    public float speedModifier = 1f;
    public bool destroyerTouch = false;
    protected SpawnManager spawnManager;

    // Start is called before the first frame update
    public virtual void Start()
    {
        spawnManager = GameObject.Find("GameController").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!WorldStatus.stopWorldMovement && !isStatic)
            transform.position -= new Vector3(0f, 0f, WorldStatus.worldSpeed + speedModifier) * Time.deltaTime;
    }

    public virtual void IncreaseSpeed(float amount)
    {
        if (amount > 0)
        {
            speedModifier += amount;
        }
        else
        {
            Debug.Log("Incorrect Sinal for IncreaseSpeed() parameter");
        }
    }
    public virtual void DecreaseSpeed(float amount)
    {
        if (amount < 0)
        {
            speedModifier += amount;
        }
        else
        {
            Debug.Log("Incorrect Sinal for DecreaseSpeed() parameter");
        }
    }
}
