using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool left { get; private set; }
    public bool right { get; private set; }

    public bool jump { get; private set; }
    public bool boost { get; private set; }
    public bool canMove { get; private set; }

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        jump = false;
        boost = false;
    }

    void Update()
    {
        left = Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.D);
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");

        if (left) horizontal = -1;
        if (right) horizontal = 1;

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
}
