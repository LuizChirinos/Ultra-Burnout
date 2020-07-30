using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOffset : MonoBehaviour
{
    Renderer renderer;
    public float velocity;
    public bool changeDirection = false;
    public bool invertScroll = false;
    private float signal;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!WorldStatus.stopWorldMovement)
        {
            signal = invertScroll ? 1 : -1;
            if (!changeDirection)
            {
                renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, -Time.time * WorldStatus.worldSpeed * 0.26f * signal));
            }
            else
                renderer.material.SetTextureOffset("_MainTex", new Vector2(-Time.time * WorldStatus.worldSpeed * 0.26f * signal, 0f));

        }
    }
}
