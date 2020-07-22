using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Components
    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerStatus status;
    #endregion

    [Header("Modifiers")]
    public float rotationAmplitude = 20f;

    #region Moving and Rotation Fields
    [HideInInspector]
    public Vector3 target;
    private Vector3 startRotation;
    private float targetAngle;
    private float angle;
    private bool changingTrack;
    #endregion

    private Tracks trackManager;
    public int trackIndex;

    public delegate void OnChangedTrack();
    public OnChangedTrack onTrackChanged = delegate { };

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        status = GetComponent<PlayerStatus>();

        trackManager = GameObject.Find("GameController").GetComponent<Tracks>();
        trackIndex = (int)Mathf.Floor(trackManager.tracks.Count/2f);

        startRotation = transform.eulerAngles;
        targetAngle = startRotation.y;
        angle = targetAngle;
        changingTrack = false;

        onTrackChanged += ChangeTrack;
        onTrackChanged += playerInput.OnActivateMovement;
    }

    void Update()
    {
        if (!WorldStatus.stopWorldMovement)
        { 
            Vector3 movement = new Vector3(playerInput.horizontal * status.speed,
                                           rb.velocity.y,
                                           rb.velocity.z);
            ModeAndClamp();
            RestoresDefaultRotation();
        }

        if (Input.GetKeyDown(KeyCode.F3))
            WorldStatus.stopWorldMovement = !WorldStatus.stopWorldMovement;

        //Debug.Log(WorldStatus.worldSpeed);
    }

    private void ModeAndClamp()
    {
        #region Clamp tracks range
        if (playerInput.right && playerInput.canMove)
        {
            onTrackChanged();
            trackIndex += 1;
            targetAngle = rotationAmplitude;
        }
        if (playerInput.left && playerInput.canMove)
        {
            onTrackChanged();
            trackIndex -= 1;
            targetAngle = -rotationAmplitude;
        }
        trackIndex = Mathf.Clamp(trackIndex, 0, trackManager.tracks.Count - 1);
        #endregion

        target = trackManager.tracks[trackIndex].position;

        angle = Mathf.Lerp(angle, targetAngle, status.speed / 2f * Time.deltaTime);
        transform.eulerAngles = new Vector3(startRotation.x, angle, startRotation.z);
        
        rb.position = Vector3.MoveTowards(transform.position, target, status.speed * Time.deltaTime);
    }
    private void RestoresDefaultRotation()
    {
        if (changingTrack && playerInput.canMove)
            changingTrack = false;

        if (!changingTrack)
        {
            targetAngle = 0f;
        }
    }
    private void ChangeTrack()
    {
        changingTrack = true;
    }
}
