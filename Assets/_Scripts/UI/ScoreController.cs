using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region
    private PlayerStatus status;
    public Text textScore;
    #endregion

    void Start()
    {
        status = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    void Update()
    {
        textScore.text = "Score: " + status.score.ToString();
    }
}
