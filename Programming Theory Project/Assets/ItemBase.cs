using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Triggered();
    }

    public virtual void Triggered()
    {
        Destroy(gameObject);
    }
}
