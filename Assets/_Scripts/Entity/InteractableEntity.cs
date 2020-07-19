using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractableEntity : Entity
{
    #region Properties
    public bool interactOnBump = true;
    public bool destroyOnInteraction = true;
    #endregion

    #region Custom Methods
    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        if (destroyOnInteraction)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
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
