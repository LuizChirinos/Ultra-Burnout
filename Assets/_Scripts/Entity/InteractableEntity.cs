using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : Entity
{
    #region Properties
    public bool interactOnBump = true;
    public bool repeatInteraction = false;
    protected bool interacted = false;
    public bool destroyOnInteraction = true;
    public bool interacbleSound = true;
    protected PlayerStatus playerStatus;

    private AudioSource audioSource;

    public delegate void OnDestroyInteraction();
    public OnDestroyInteraction onDestroyInteraction = delegate { };

    #endregion

    public override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();

        onDestroyInteraction += Remove;
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    #region Custom Methods
    public virtual void Interact()
    {
        if (CanInteract())
        {

            if (!repeatInteraction)
            {
                interacted = true;
                if (audioSource && interacbleSound)
                    audioSource.Play();
            }

            //Debug.Log("Interacted with " + gameObject.name);
            if (destroyOnInteraction)
            {
                onDestroyInteraction();
            }
        }
    }
    public bool CanInteract()
    {
        return !interacted;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (interactOnBump)
        {
            if (other.CompareTag("Player"))
            {
                Interact();
            }
            if (other.CompareTag("Destroyer"))
            {
                if (destroyerTouch)
                {
                    onDestroyInteraction();
                }
            }
        }
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (interactOnBump)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Interact();
            }
            if (collision.gameObject.CompareTag("Destroyer"))
            {
                if (destroyerTouch)
                {
                    onDestroyInteraction();
                }
            }
        }
    }

    public void Remove()
    {
        spawnManager.RemoveObject(this.gameObject);
    }
    #endregion
}
