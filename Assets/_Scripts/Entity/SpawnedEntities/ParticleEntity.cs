using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEntity : InteractableEntity
{
    private ParticleSystem ps;
    public bool destroyAfterFinished = true;

    public override void Start()
    {
        base.Start();

        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }
    public override void Update()
    {
        base.Update();

        if (!ps.IsAlive() && destroyAfterFinished)
        {
            Destroy(this.gameObject);
        }

        if (WorldStatus.stopWorldMovement || WorldStatus.worldSpeed <= 0.1f)
        {
            Debug.Log("Para particula");
            ps.Stop();
            //main.simulationSpeed = 0f;
        }
        else
        {
            //Debug.Log("Toca particula");
            ps.Play();
            //main.simulationSpeed = 1f;
        }
    }
}
