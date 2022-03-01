using UnityEngine;
using TMPro;

public class UI_Canvas : MonoBehaviour
{
    public static UI_Canvas Instance;
    [SerializeField] private TextMeshProUGUI timerText;

    void Awake()
    {
        Instance = this;
        timerText.text = "";
    }
    public void SetTimeDisplay(string timer)
    {
        timerText.text = timer;
    }
}
