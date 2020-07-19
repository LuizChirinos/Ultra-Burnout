using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStatus
{
    public static float worldSpeed = 5;
    public static bool stopWorldMovement = false;

    #region Custom Methods
    public static void IncreaseWorldSpeed(int amount)
    {
        if (amount > 0)
        {
            worldSpeed += amount;
        }
        else
        {
            Debug.Log("Incorrect Sinal for IncreaseSpeed() parameter");
        }
    }
    public static void DecreaseWorldSpeed(int amount)
    {
        if (amount < 0)
        {
            worldSpeed += amount;
        }
        else
        {
            Debug.Log("Incorrect Sinal for IncreaseSpeed() parameter");
        }
    }
    public static void StopWorld(bool value)
    {
        stopWorldMovement = value;
    }

    #endregion
}
