using UnityEngine;
using TMPro;

public class UI_Canvas : MonoBehaviour
{
    public static UI_Canvas Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winText;

    void Awake()
    {
        Instance = this;
        timerText.text = "";
        winText.enabled = false;
    }
    public void SetTimeDisplay(string timer)
    {
        timerText.text = timer;
    }

    public void WinTrigger()
    {
        winText.enabled = true;
    }
}
