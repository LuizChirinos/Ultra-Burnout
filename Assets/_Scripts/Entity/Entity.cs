using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool isStatic = false;
    public float speedModifier = 1f;

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
}
