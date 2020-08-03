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
        //WorldStatus.StopWorld();
    }
    private void Update()
    {
        count -= Time.deltaTime;
        if (count <= 0f && WorldStatus.worldSpeed >= 0.1f)
        {
            count = timeToChange;
            //Debug.Log("Velocity Increased by Time");
            WorldStatus.IncreaseWorldSpeed(speedMultiplier);
        }
    }

}
