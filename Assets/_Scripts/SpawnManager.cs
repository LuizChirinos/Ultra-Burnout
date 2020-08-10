using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform spawnParent;
    private Transform scenario;
    private Transform spawnedObjectParent;
    public List<Transform> spawns;

    private int maxObjects = 10;
    public List<GameObject> spawnedGameObjects;

    [System.Serializable]
    public class SpawnObject
    {
        public GameObject objectToSpawn;
        public int chanceToSpawn;
    }
    [System.Serializable]
    public class SpawnInfo
    {
        public List<SpawnObject> spawnObjects;
        public float counterSpawn;
        public float timeToSpawn = 1f;
    }
    public SpawnInfo[] spawnInfo;

    [Header("Spawn Fields")]
    public bool spawnedGas = false;
    public int randomTrack;
    public int randomObject;

    void Start()
    {
        spawnParent = GameObject.Find("Spawns").transform;
        scenario = GameObject.Find("Scenario").transform;
        spawnedObjectParent = scenario.Find("Spawned Objects");

        for (int i = 0; i < spawnParent.childCount; i++)
        {
            spawns.Add(spawnParent.GetChild(i));
        }

        spawnInfo[0].counterSpawn = spawnInfo[0].timeToSpawn;
    }

    void Update()
    {
        spawnInfo[0].counterSpawn -= Time.deltaTime * WorldStatus.worldSpeed / 10f;
        if (spawnInfo[0].counterSpawn <= 0f)
        {
            spawnInfo[0].counterSpawn = spawnInfo[0].timeToSpawn;
            randomTrack = Random.Range(0, spawns.Count);
            RandomizeSpawn();
        }
        if (spawnInfo[1].counterSpawn <= 0f)
        {
            spawnInfo[1].counterSpawn = spawnInfo[1].timeToSpawn;
            randomTrack = Random.Range(0, spawns.Count);
            InstantiateObject(1, 0);
        }
    }
    private void RandomizeSpawn()
    {
        for (int i = 0; i < spawnInfo[0].spawnObjects.Count; i++)
        {
            randomObject = Random.Range(0, 10);

            if (randomObject <= spawnInfo[0].spawnObjects[i].chanceToSpawn)
            {
                spawnInfo[0].counterSpawn = spawnInfo[0].timeToSpawn;
                if (spawnInfo[0].spawnObjects[i].objectToSpawn.name.Contains("Gas") && spawnedGas)
                {
                    continue;
                }
                else if (spawnInfo[0].spawnObjects[i].objectToSpawn.name.Contains("Gas") && !spawnedGas)
                    spawnedGas = true;

                InstantiateObject(0, i);

                break;
            }
            else
                continue;
        }
    }
    public void RespawnAt(Transform spawnObject, int indexPosition)
    {
        spawnObject.position = spawns[indexPosition].position;
    }
    public void InstantiateObject(int spawnInfoIndex, int indexObject)
    {
        GameObject instantiatedObject = Instantiate(spawnInfo[spawnInfoIndex].spawnObjects[indexObject].objectToSpawn, spawns[randomTrack].position, Quaternion.identity, spawnedObjectParent) as GameObject;
    }
    public void RemoveObject(GameObject reference)
    {
        Destroy(reference);
    }
}
