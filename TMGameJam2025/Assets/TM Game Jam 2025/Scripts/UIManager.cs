using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private GameObject scorePanel; 
    [SerializeField] private TextMeshProUGUI finalScoreText; 

    public bool startTime;
    private float startTimeValue;

    void Start()
    {
        if (scorePanel != null)
            scorePanel.SetActive(false); 
    }


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

    public void ShowFinalScore(int score)
    {
        if (scorePanel != null && finalScoreText != null)
        {
            scorePanel.SetActive(true);
            float time = Time.time - startTimeValue;
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            finalScoreText.text = $"Final Score: {score}\nTime: {minutes:00}:{seconds:00}";
            startTime = false; 
        }
    }
}
