using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    public enum RotationAxis { x, y, z};
    public RotationAxis rotationAxis;

    [SerializeField] private float speed;

    void FixedUpdate()
    {

            transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
