using UnityEngine;

public class ItemBase : MonoBehaviour
{
    private ObjectSpawner objectSpawner;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Triggered();
    }

    public void SpawnMe(ObjectSpawner spawner)
    {
        objectSpawner = spawner;
    }

    public virtual void Triggered()
    {
        objectSpawner.CollectObject();
        Destroy(gameObject);
    }
}
