using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float gasoline { get; private set; }
    public float maxGasoline { get; private set; }

    public float hp { get; private set; }
    public float maxhp { get; private set; }

    public float speed { get; set; }
    public float score;
    [HideInInspector]
    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        hp = maxhp;
        gasoline = maxGasoline;
        isMoving = true;
    }

    #region Gasoline Methods
    public void SetGasoline(float value)
    {
        gasoline = value;
    }
    public void ChangeGasoline(float amount)
    {
        gasoline += amount;
    }
    public void SetMaxGasoline(float maxValue)
    {
        maxGasoline = maxValue;
    }
    #endregion
    #region Score Methods
    public void ChangeScore(float amount)
    {
        score += amount;
        score = Mathf.Ceil(score);
    }
    public void SetScore (float value)
    {
        score = value;
        score = Mathf.Ceil(score);
    }
    #endregion
}
