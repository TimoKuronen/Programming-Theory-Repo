using UnityEngine;

public class GameManager : MonoBehaviour
{
    // "ENCAPSULATION” //
    public static GameManager Instance { get; private set; }

    [SerializeField] private float matchDuration;

    public bool gameWon;
    private bool matchStarted;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerManager.Instance.ControlLock(true);
        Invoke(nameof(StartMatch), 1);
    }

    void StartMatch()
    {
        PlayerManager.Instance.ControlLock(false);
        SpawnerManager.Instance.StartSpawning();
        matchStarted = true;
    }

    void Update()
    {
        if (matchStarted && !gameWon)
        {
            matchDuration += Time.deltaTime;
            SetTimer();
        }
    }

    void SetTimer()
    {
        int minutes = Mathf.FloorToInt(matchDuration / 60F);
        int seconds = Mathf.FloorToInt(matchDuration - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        UI_Canvas.Instance.SetTimeDisplay(niceTime);
    }

    public void PlayerScored()
    {
        gameWon = true;
        UI_Canvas.Instance.WinTrigger();
        Time.timeScale = 0.0000000001f;
    }
}
