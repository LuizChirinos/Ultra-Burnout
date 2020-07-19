using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOffset : MonoBehaviour
{
    Renderer renderer;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!WorldStatus.stopWorldMovement)
            renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, -Time.time * WorldStatus.worldSpeed * 0.26f));
    }
}
