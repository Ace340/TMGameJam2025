using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    public bool startTime;
    private float startTimeValue;
    void Update()
    {
        UpdateScore();
        UpdateTime();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.Score;
    }

    private void UpdateTime()
    {

        if (startTime)
        {
            float time = Time.time - startTimeValue;

            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);

            timeText.text = $"Time: {minutes:00}:{seconds:00}";

        }
    }

    public void StartTimer()
    {
        startTimeValue = Time.time;
        startTime = true;
    }
}
