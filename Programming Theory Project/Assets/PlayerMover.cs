using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public static PlayerMover Instance;

    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float acceleration;

    private float currentSpeed;
    private float x,z;
    private Rigidbody rig;
    private float maxVelocity = 3f;

    private void Awake()
    {
        Instance = this;
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        RotatePlayer();
        MovePlayer();
    }

    private void GetInput()
    {
        x = PlayerManager.Instance.x;
        z = PlayerManager.Instance.z;

        if (x == 0 && z == 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);
        }
    }

    private void RotatePlayer()
    {
        transform.RotateAround(transform.position, Vector3.up, z * rotateSpeed * Time.deltaTime);
        rig.angularVelocity = Vector3.zero;
    }

    private void MovePlayer()
    {
        if (x == 0)
            rig.velocity = Vector3.zero;

        if (rig.velocity.magnitude > maxVelocity || PlayerManager.Instance.IsInputLocked || PlayerManager.Instance.HasBall)
            return;

        if (x > 0)
            rig.AddForce(currentSpeed * -transform.forward);
        else if (x < 0)
            rig.AddForce(currentSpeed * transform.forward);
    }

    public IEnumerator BoostSpeed(float powerIncrease, float powerDuration)
    {
        speed += powerIncrease;

        yield return new WaitForSeconds(powerDuration);

        speed -= powerIncrease;
    }
}
