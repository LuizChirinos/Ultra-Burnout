using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChageSpeed : MonoBehaviour
{
    private float count;
    private float timeToChange = 10f;
    private float speedMultiplier = 1f;
    
    void Start()
    {
        count = 0f;
        count = timeToChange;
    }
    private void Update()
    {
        count -= Time.deltaTime;
        if (count <= 0f)
        {
            count = timeToChange;
            Debug.Log("Velocity Increased by Time");
            WorldStatus.IncreaseWorldSpeed(speedMultiplier);
        }
    }

}
