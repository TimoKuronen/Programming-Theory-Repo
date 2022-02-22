using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageReceiver
{
    public static PlayerManager Instance;
    private bool inputLocked;
    private bool gotTheBall;
    private Vector3 startPosition;
    public bool IsInputLocked => inputLocked;

    public float x, z;

    [SerializeField] private float kickPower;

    void Awake()
    {
        Instance = this;
        startPosition = this.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            inputLocked = !inputLocked;

        if (IsInputLocked)
            return;

        GetInput();
    }

    void GetInput()
    {
        x = -Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("Jump"))
            KickTheBall();
    }

    public void ControlLock(bool value)
    {
        inputLocked = value;
    }

    void KickTheBall()
    {

    }

    IEnumerator RestartPosition()
    {
        ControlLock(true);
        transform.position = startPosition;

        yield return new WaitForSeconds(1);

        ControlLock(false);
    }

    void BallTrigger(bool value)
    {
        gotTheBall = value;
    }

    public void TouchTrap()
    {
        StartCoroutine(RestartPosition());
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("player hit object " + other.gameObject);
        if (other.gameObject.CompareTag("Trap"))
            TouchTrap();
    }

    public IEnumerator BoostPower(float powerIncrease, float powerDuration)
    {
        kickPower += powerIncrease;

        yield return new WaitForSeconds(powerDuration);

        kickPower -= powerIncrease;
    }
}
