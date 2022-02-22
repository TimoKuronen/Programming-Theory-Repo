using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMover : MonoBehaviour
{
    [SerializeField] private bool useXaxis;
    [SerializeField] private float distanceToMove;
    private float speed;
    private float waitDuration;
    private bool activated;

    void Start()
    {
        speed = Random.Range(2, 4);
        waitDuration = Random.Range(0, 1.5f);
        Invoke("ActivateTrap", Random.Range(0, 2));
    }

    void ActivateTrap()
    {
        activated = true;
    }

    void FixedUpdate()
    {
        if (!activated)
            return;

        if (useXaxis)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, distanceToMove) - distanceToMove / 2f, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, distanceToMove) - distanceToMove / 2f);
    }
}
