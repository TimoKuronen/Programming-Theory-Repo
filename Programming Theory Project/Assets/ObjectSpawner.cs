using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefab;

    private bool objectSpawned;
    public bool ObjectIsSpawned => objectSpawned;

    private void Start()
    {
        SpawnerManager.Instance.AddSpawnerToList(this);
    }

    public void SpawnObject()
    {
        objectSpawned = true;
        int random = Random.Range(0, 2);
        var obj = Instantiate(objectPrefab[random], transform.position, transform.rotation, null);
        obj.GetComponent<ItemBase>().SpawnMe(this);
    }

    public void CollectObject()
    {
        objectSpawned = false;
        SpawnerManager.Instance.Despawned();
    }
}
