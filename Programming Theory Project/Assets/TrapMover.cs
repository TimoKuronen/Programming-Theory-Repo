using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMover : MonoBehaviour
{
    [SerializeField] private bool useXaxis;
    [SerializeField] private float distanceToMove;
    [SerializeField] private float speed;
    private float waitDuration;
    private bool activated;
    private Vector3 startPosition;

    void Start()
    {
        speed *= Random.Range(0.75f, 1.25f);
        waitDuration = Random.Range(0, 1.5f);
        Invoke("ActivateTrap", Random.Range(0, 2));
        startPosition = transform.position;
    }

    void ActivateTrap()
    {
        activated = true;
    }

    void FixedUpdate()
    {
        if (!activated)
            return;

        transform.position = startPosition + transform.forward * Mathf.Sin(Time.time * waitDuration) * speed;
    }
}
