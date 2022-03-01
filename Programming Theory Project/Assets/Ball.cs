using UnityEngine;

public class Ball : MonoBehaviour, IDamageReceiver
{
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    public void TouchTrap()
    {
        transform.position = startPosition;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}