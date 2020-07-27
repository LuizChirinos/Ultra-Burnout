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

    // Start is called before the first frame update
    public virtual void Start()
    {
        
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

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer"))
        {
            if (destroyerTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            if (destroyerTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
