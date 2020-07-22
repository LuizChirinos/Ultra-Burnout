using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEntity : InteractableEntity
{
    private ParticleSystem ps;

    public override void Start()
    {
        base.Start();

        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }
    public override void Update()
    {
        base.Update();

        if (!ps.IsAlive())
        {
            Destroy(this.gameObject);
        }

        if (WorldStatus.stopWorldMovement)
        {
            ps.playbackSpeed = 0f;
        }
        else
            ps.playbackSpeed = 1f;

    }
}
