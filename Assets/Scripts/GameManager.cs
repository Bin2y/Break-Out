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

    public BreakOutSO[] breakOutDB;

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
        InitGame();
    }

    private void InitGame()
    {
        //씬번호랑 리스트 번호랑 통일시켜야함
        //스테이지가 넘어갈때마다 InitGame()호출
        brickCount = breakOutDB[SceneManager.GetActiveScene().buildIndex].brickCount;
        ballCount = breakOutDB[SceneManager.GetActiveScene().buildIndex].ballCount;
    }



    private void StageClear()
    {
        if(brickCount == 0)
        {
            //스테이지 클리어
        }
    }

    private void EndGame()
    {
        if(ballCount <= 0)
        {
            //게임종료
        }
    }


}
