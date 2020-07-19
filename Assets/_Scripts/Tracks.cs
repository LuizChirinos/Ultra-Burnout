using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    private Transform scenario;
    private Transform trackParent;
    public List<Transform> tracks;

    [System.Serializable]
    public class TrackInfo
    {
        public Transform position;
    }

    // Start is called before the first frame update
    void Start()
    {
        scenario = GameObject.Find("Scenario").transform;
        trackParent = scenario.Find("Tracks");
        tracks = new List<Transform>();

        for (int i = 0; i < trackParent.childCount; i++)
        {
            tracks.Add(trackParent.GetChild(i));
            //Debug.Log(tracks[i].name);
        }
    }
}
