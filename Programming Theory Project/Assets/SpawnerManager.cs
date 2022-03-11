using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance { get; private set; }
    [SerializeField] private int spawnCount;
    [SerializeField] private int spawnInterval;

    private List<ObjectSpawner> spawners = new List<ObjectSpawner>();
    private int spawnedObjectsCount;

    private void Awake()
    {
        Instance = this;
    }

    public void StartSpawning()
    {
        for (int i = 0; i < spawnCount - 1; i++)
        {
            SpawnObject();
        }

        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    public void AddSpawnerToList(ObjectSpawner objectSpawner)
    {
        spawners.Add(objectSpawner);
    }

    private void SpawnObject()
    {
        if (spawnedObjectsCount >= spawnCount)
            return;

        bool objectSpawned = false;
        while (!objectSpawned)
        {
            int randomIndex = Random.Range(0, spawners.Count);
            if(!spawners[randomIndex].ObjectIsSpawned)
            {
                spawners[randomIndex].SpawnObject();
                objectSpawned = true;
                spawnedObjectsCount++;
            }
        }
    }

    public void Despawned()
    {
        spawnedObjectsCount--;
    }
}
