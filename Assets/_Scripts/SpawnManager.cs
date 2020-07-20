using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum Spot
    {
        Left,Middle, Right
    }

    private Transform spawnParent;
    public List<Transform> spawns;

    public GameObject enemy;
    public GameObject obstacle;
    public GameObject gasoline;
    public GameObject coin;

    public int randomTrack;
    public float counterSpawn;
    public float timeToSpawn = 1f;

    void Start()
    {
        spawnParent = GameObject.Find("Spawns").transform;
        for (int i = 0; i < spawnParent.childCount; i++)
        {
            spawns.Add(spawnParent.GetChild(i));
        }

        counterSpawn = timeToSpawn;
    }

    void Update()
    {
        counterSpawn -= Time.deltaTime;
        if (counterSpawn <= 0f)
        {
            randomTrack = Random.Range(0, spawns.Count);
            RandomizeSpawn();
        }
    }
    private void RandomizeSpawn()
    {

    }
    public void RespawnAt(Transform spawnPosition, int indexPosition)
    {
        spawnPosition.position = spawns[indexPosition].position;
    }
}
