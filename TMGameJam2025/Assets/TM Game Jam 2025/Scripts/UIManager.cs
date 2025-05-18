using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

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
        float time = Time.time;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
