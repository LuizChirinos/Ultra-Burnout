using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform spawnParent;
    public List<Transform> spawns;

    public GameObject enemy;
    public GameObject obstacle;
    public GameObject gasoline;
    public GameObject coin;

    void Start()
    {
        spawnParent = GameObject.Find("Spawns").transform;
        for (int i = 0; i < spawnParent.childCount; i++)
        {
            spawns.Add(spawnParent.GetChild(i));
        }
    }

    void Update()
    {
        
    }
}
