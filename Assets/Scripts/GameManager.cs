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
