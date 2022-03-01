using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - followObject.transform.position;
    }

    void Update()
    {
        transform.position = followObject.transform.position + offset;
    }
}
