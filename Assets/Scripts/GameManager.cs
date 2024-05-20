using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int brickCount { get; set; }
    private int ballCount { get; set; }

    public int currentScore = 0;
    public int highestScore = 0;


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
        Debug.Log("게임시작");
    }




    private void StageClear()
    {
        if (brickCount == 0)
        {
            CheckScore();
            //스테이지 클리어
        }
    }

    private void EndGame()
    {
        if (ballCount <= 0)
        {
            CheckScore();
            //게임종료
        }
    }

    private void CheckScore()
    {
        if (highestScore < currentScore)
        {
            highestScore = currentScore;
        }
    }


}
