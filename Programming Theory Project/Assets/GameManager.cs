using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameWon;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerManager.Instance.ControlLock(true);
    }

    void StartMatch()
    {
        PlayerManager.Instance.ControlLock(false);
    }

    public void PlayerScored()
    {
        gameWon = true;
        Time.timeScale = 0;
    }
}
