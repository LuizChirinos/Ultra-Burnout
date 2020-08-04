using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region
    private PlayerStatus status;
    public Text textScore;
    private float scoreModifier = 2f;
    #endregion

    void Start()
    {
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    void Update()
    {
        float signal = WorldStatus.stopWorldMovement ? 0 : 1;
        textScore.text = status.score.ToString("0") + "X";
        status.score += (Time.deltaTime * scoreModifier * signal);
    }
}
