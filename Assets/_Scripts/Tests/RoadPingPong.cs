using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPingPong : MonoBehaviour
{
    public Transform pathParent;
    private PathCreator creator;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        creator = pathParent.GetComponentInChildren<PathCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        var bezierPath = creator.editorData.bezierPath;

        float range = Mathf.PingPong(Time.time, speed);

        Vector3 finalposition = bezierPath.points[bezierPath.points.Count - 1];
        bezierPath.SetPoint(bezierPath.points.Count-1, finalposition);
        Debug.Log(bezierPath.GetPoint(bezierPath.points.Count - 1));
    }
}
