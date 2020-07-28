using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform spawnParent;
    private Transform scenario;
    private Transform spawnedObjectParent;
    public List<Transform> spawns;
    public List<SpawnObject> objectsToSpawn;


    [SerializeField]
    private int amountSpawnedObjects;
    private int maxObjects = 10;
    public List<GameObject> spawnedGameObjects;
    private int indexSpawnedObjects;

    [System.Serializable]
    public class SpawnObject
    {
        public GameObject objectToSpawn;
        public int chanceToSpawn;

    }

    [Header("Spawn Fields")]
    public bool spawnedGas = false;
    public int randomTrack;
    public int randomObject;
    public float counterSpawn;
    public float timeToSpawn = 1f;

    void Start()
    {
        spawnParent = GameObject.Find("Spawns").transform;
        scenario = GameObject.Find("Scenario").transform;
        spawnedObjectParent = scenario.Find("Spawned Objects");

        for (int i = 0; i < spawnParent.childCount; i++)
        {
            spawns.Add(spawnParent.GetChild(i));
        }

        counterSpawn = timeToSpawn;
        indexSpawnedObjects = 0;
    }

    void Update()
    {
        counterSpawn -= Time.deltaTime * WorldStatus.worldSpeed / 10f;
        if (counterSpawn <= 0f)
        {
            counterSpawn = timeToSpawn;
            randomTrack = Random.Range(0, spawns.Count);
            RandomizeSpawn();
        }
    }
    private void RandomizeSpawn()
    {
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            randomObject = Random.Range(0, 10);

            if (randomObject <= objectsToSpawn[i].chanceToSpawn)
            {
                counterSpawn = timeToSpawn;
                if (i == 1 && spawnedGas)
                {
                    continue;
                }
                else if (i == 1 && !spawnedGas)
                    spawnedGas = true;

                InstantiateObject(i);

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
    public void InstantiateObject(int index)
    {
        if (amountSpawnedObjects < maxObjects)
        {
            GameObject instantiatedObject = Instantiate(objectsToSpawn[index].objectToSpawn, spawns[randomTrack].position, Quaternion.identity, spawnedObjectParent) as GameObject;

            spawnedGameObjects.Add(instantiatedObject);
            amountSpawnedObjects += 1;
        }
        else
        {
            RespawnAt(spawnedGameObjects[indexSpawnedObjects].transform, Random.Range(0, spawns.Count));
            Debug.Log("Spawned GameObject" + spawnedGameObjects[indexSpawnedObjects].name);
            indexSpawnedObjects += 1;
            indexSpawnedObjects %= spawnedGameObjects.Count;
        }
    }
    public void RemoveObject(GameObject reference)
    {
        amountSpawnedObjects -= 1;
        spawnedGameObjects.Remove(this.gameObject);
        Destroy(reference);
    }
}
