using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class GasolineController : MonoBehaviour
{
    #region Properties
    [Header("Main Fields")]

    //Main Properties
    private PlayerStatus status;
    private WorldChageSpeed worldChageSpeed;
    public Image gasolineFill;

    private float maxGasolineModifier = 6f;
    //Change this value if yout want to change the gasoline consume
    public float gasolineModifier { get; set; }

    //Some items might change the amount of gasoline consume
    public float gasolineConsume { get; private set; }
    #endregion

    void Start()
    {
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        worldChageSpeed = GameObject.Find("GameController").GetComponent<WorldChageSpeed>();
        worldChageSpeed.onChangeSpeed += ModifyGasolineConsume;

        status.SetMaxGasoline(100f);
        status.ChangeGasoline (status.maxGasoline);
        gasolineModifier = 3f;
    }

    void Update()
    {
        float signal = WorldStatus.stopWorldMovement ? 0 : 1;
        gasolineConsume = gasolineModifier * Time.deltaTime * signal;
        gasolineModifier = Mathf.Clamp(gasolineModifier, 0f, maxGasolineModifier);
        status.ChangeGasoline(-gasolineConsume);
        status.SetGasoline(Mathf.Clamp(status.gasoline, 0f, status.maxGasoline));
        gasolineFill.fillAmount = ExtensionMethods.Remap(status.gasoline, 0f, status.maxGasoline, 0f, 1f);

        
        if (status.gasoline <= 0)
        {
            //Debug.Log("Acabou a gasolina");
            WorldStatus.worldSpeed = Mathf.Lerp(WorldStatus.worldSpeed, 0f, 0.01f);
            if (Mathf.Abs(WorldStatus.worldSpeed) < 0.3f)
                WorldStatus.worldSpeed = 0f;
        }
    }

    #region Custom Methods
    public void ModifyGasolineConsume(float amountToModify)
    {
        if (amountToModify/2f > 0)
        {
            Debug.Log("Gasoline Consume Increased");
            gasolineModifier += amountToModify;
        }
        else if(amountToModify/2f < 0)
        {
            Debug.Log("Gasoline Consume Decreased");
            gasolineModifier += amountToModify;
        }
        else if (amountToModify/2f == 0)
        {
            Debug.Log("Gasoline Consume was not modified, try a different value");
        }
    }
    #endregion
}
