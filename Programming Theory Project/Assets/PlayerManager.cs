using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageReceiver
{
    public static PlayerManager Instance;
    [SerializeField] private float kickPower;
    [SerializeField] private Transform ballPosition;
    [HideInInspector] public float x, z;

    private bool inputLocked;
    private bool gotTheBall;
    private Vector3 startPosition;
    private Rigidbody ballObject;

    public bool IsInputLocked => inputLocked;
    public bool HasBall => gotTheBall;

    private void Awake()
    {
        Instance = this;
        startPosition = this.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsInputLocked && gotTheBall)
                return;

            inputLocked = !inputLocked;
        }

        if (IsInputLocked)
            return;

        GetInput();
    }

    private void GetInput()
    {
        x = -Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
            KickTheBall();
    }

    public void ControlLock(bool value)
    {
        inputLocked = value;
    }

    private void KickTheBall()
    {
        if (!gotTheBall)
            return;

        BallTrigger(false);

        ballObject.AddExplosionForce(kickPower, transform.position, 1);
        ballObject = null;
    }

    private IEnumerator RestartPosition()
    {
        ControlLock(true);
        transform.position = startPosition;

        yield return new WaitForSeconds(1);

        ControlLock(false);
    }

    private void BallTrigger(bool value, Rigidbody ball = default)
    {
        gotTheBall = value;

        if (value)
        {
            ball.isKinematic = value;
            ballObject = ball;
            ballObject.transform.SetParent(ballPosition);
            ballObject.transform.localPosition = Vector3.zero;
            ballObject.velocity = Vector3.zero;
        }
        else
        {
            ballObject.isKinematic = value;
            ballObject.transform.SetParent(null);           
        }
    }

    public void TouchTrap()
    {
        StartCoroutine(RestartPosition());
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("player hit object " + other.gameObject);
        if (other.gameObject.CompareTag("Trap"))
            TouchTrap();
        else if (other.gameObject.CompareTag("Ball"))
        {
            if (gotTheBall)
                return;

            BallTrigger(true, other.gameObject.GetComponent<Rigidbody>());
        }
    }

    public IEnumerator BoostPower(float powerIncrease, float powerDuration)
    {
        kickPower += powerIncrease;

        yield return new WaitForSeconds(powerDuration);

        kickPower -= powerIncrease;
    }
}
