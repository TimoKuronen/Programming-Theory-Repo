using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public static PlayerMover Instance;
    CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    private Vector3 moveAmount;
    private float currentSpeed;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        float x = PlayerManager.Instance.x;
        float z = PlayerManager.Instance.z;

        moveAmount = new Vector3(x, 0, z);
        if (x == 0 && z == 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);
        }
    }

    void MovePlayer()
    {
        if (!PlayerManager.Instance.IsInputLocked)
            characterController.SimpleMove(moveAmount * currentSpeed);
        else
        {
            transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

    public IEnumerator BoostSpeed(float powerIncrease, float powerDuration)
    {
        speed += powerIncrease;

        yield return new WaitForSeconds(powerDuration);

        speed -= powerIncrease;
    }
}
