using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool left { get; private set; }
    public bool right { get; private set; }
    public bool swiped { get; private set; }


    public bool jump { get; private set; }
    public bool boost { get; private set; }
    public bool canMove { get; private set; }

    private PlayerMovement playerMovement;

    private SwipeDetector swipeDetector;

    void Start()
    {
        swipeDetector = GameObject.Find("GameController").GetComponent<SwipeDetector>();
        playerMovement = GetComponent<PlayerMovement>();
        jump = false;
        boost = false;
        SwipeDetector.OnSwipe += CheckLeft;
        SwipeDetector.OnSwipe += CheckRight;

        playerMovement.onTrackChanged += RestoreMovement;
    }

    void Update()
    {
#if UNITY_EDITOR
        left = Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.D);
#endif

        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        if (left)
        {
            horizontal = -1;
        }
        if (right)
        {
            horizontal = 1;
        }

        canMove = Mathf.Abs(transform.position.x - playerMovement.target.x) < 0.3f ? true : false;

    }

    public void OnActivateMovement()
    {
        canMove = false;
    }

    public void Left(bool value)
    {
        left = value;
    }
    public void Right(bool value)
    {
        right = value;
    }
    public void CheckLeft(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Left)
        {
            left = true;
        }
    }
    public void CheckRight(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Right)
        {
            right = true;
        }
    }
    public void RestoreMovement()
    {
        left = false;
        right = false;
    }
}
