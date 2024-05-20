using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject canvasPrefab;
    private ScoreBoard scoreBoard;

    private int brickCount { get; set; }
    private int ballCount { get; set; }

    public int currentScore = 4;
    public int highestScore = 4;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (brickCount == 0)
        {
            StageClear();
        }
        if (ballCount == 0)
        {
            EndGame();
        }
    }

    public void Init()
    {
        MakeScoreBoard();
        //TODO : 스테이지별로 벽돌갯수랑 ball갯수 등록
    }
    private void MakeScoreBoard()
    {
        scoreBoard = Instantiate(canvasPrefab).GetComponent<ScoreBoard>();
    }

    private void StageClear()
    {
        CheckScore();
        scoreBoard?.retryButton.SetActive(true);
        //TODO : 다음 스테이지로 넘어가기
    }

    private void EndGame()
    {
        CheckScore();
        scoreBoard?.retryButton.SetActive(true);
    }

    private void CheckScore()
    {
        if (highestScore < currentScore)
        {
            highestScore = currentScore;
        }
    }

}
