using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractableEntity : Entity
{
    #region Properties
    public bool interactOnBump = true;
    public bool repeatInteraction = false;
    private bool interacted = false;
    public bool destroyOnInteraction = true;
    public bool interacbleSound = true;

    private AudioSource audioSource;
    #endregion

    public override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
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

            Debug.Log("Interacted with " + gameObject.name);
            if (destroyOnInteraction)
                Destroy(this.gameObject);
        }
    }
    public bool CanInteract()
    {
        return !interacted;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (interactOnBump)
        {
            if (other.CompareTag("Player"))
            {
                Interact();
            }
        }
    }
    #endregion
}
