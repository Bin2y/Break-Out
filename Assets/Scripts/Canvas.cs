using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI MaxScoreLiveText;
    [SerializeField] private TextMeshProUGUI highestScoreLiveText;
    [SerializeField] private TextMeshProUGUI currentScoreLiveText;
    [SerializeField] private GameObject scoreBoard;

    [SerializeField] private int stageLevel;

    public GameObject retryButton;
    public GameObject nextStageButton;

    private void Start()
    {
        stageLevel = GameManager.StageLevel;
    }

    private void Update()
    {
        MaxScoreLiveText.text = "Max Score : " + GameManager.instance.maxScore;
        currentScoreLiveText.text = "Current Score : " + GameManager.instance.currentScore;
        highestScoreLiveText.text = "highest Score : " + GameManager.instance.highestScores[stageLevel];

        if (GameManager.instance.isFail) ShowFailBoard();
        if (GameManager.instance.isClear) ShowClearBoard();
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
