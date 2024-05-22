using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    [SerializeField] private TextMeshProUGUI MaxScoreLiveText;
    [SerializeField] private TextMeshProUGUI currentScoreLiveText;
    [SerializeField] private TextMeshProUGUI highestScoreLiveText;
    [SerializeField] private GameObject scoreBoard;

    public GameObject retryButton;
    public GameObject nextStageButton;
    private int stageLevel;

    private void Start()
    {
        stageLevel = GameManager.StageLevel;
    }

    private void Update()
    {
        MaxScoreLiveText.text = "Max Score : " + GameManager.instance.maxScore;
        currentScoreLiveText.text = "Current Score : " + GameManager.instance.currentScore;
        highestScoreLiveText.text = "highest Score : " + GameManager.instance.highestScores[stageLevel];
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextStage()
    {
        GameManager.StageLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PreviousStage()
    {
        GameManager.StageLevel--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowFailBoard()
    {
        scoreBoard.SetActive(true);
        maxScoreText.text = "Max Score : " + GameManager.instance.maxScore;
        currentScoreText.text = "Current Score : " + GameManager.instance.currentScore;
        highestScoreText.text = "highest Score : " + GameManager.instance.highestScores[stageLevel];
        retryButton.SetActive(true);
    }

    public void ShowClearBoard()
    {
        scoreBoard.SetActive(true);
        maxScoreText.text = "Max Score : " + GameManager.instance.maxScore;
        currentScoreText.text = "Current Score : " + GameManager.instance.currentScore;
        highestScoreText.text = "highest Score : " + GameManager.instance.highestScores[stageLevel];
        nextStageButton.SetActive(true);
    }
}
