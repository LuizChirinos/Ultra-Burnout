using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldStatus
{
    public static float worldSpeed = 10f;
    public static bool stopWorldMovement = false;
    public static float maxSpeed = 30f;

    #region Custom Methods
    public static void IncreaseWorldSpeed(float amount)
    {
        if (amount > 0)
        {
            worldSpeed += amount;
            worldSpeed = Mathf.Clamp(worldSpeed, 0f, maxSpeed);
        }
        else
        {
            Debug.Log("Incorrect Sinal for IncreaseSpeed() parameter");
        }
    }
    public static void DecreaseWorldSpeed(float amount)
    {
        if (amount < 0)
        {
            worldSpeed += amount;
            worldSpeed = Mathf.Clamp(worldSpeed, 0f, maxSpeed);
        }
        else
        {
            Debug.Log("Incorrect Sinal for DecreaseSpeed() parameter");
        }
    }
    public static void StopWorld(bool value)
    {
        stopWorldMovement = value;
    }

    #endregion
}
