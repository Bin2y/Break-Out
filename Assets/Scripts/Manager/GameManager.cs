using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int StageLevel { get; set; }

    public int currentScore = 0;
    public int highestScore = 0;

    public int BrickCount { get; set; }
    public int BallCount { get; set; }

    [TextArea]
    [SerializeField] private string[] BrickStrs;
    
    [SerializeField] private GameObject brick;

    //Offset: 위치 조정 위한 값, Gap: 벽돌 사이 간격
    //xOffset: -6.3 yOffset: 0.6 xGap: 2.1 yGap: 0.55
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float xGap;
    [SerializeField] private float yGap;
    private GameObject bricks;
    private string brickStr;

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

    private void Update()
    {
        if (BrickCount == 0)
        {
            StageClear();
        }
        if (BallCount == 0)
        {
            EndGame();
        }
        Debug.Log("ballCount : " + BallCount + " BrickCount : " + BrickCount);
    }

    public void StageInit()
    {
        BrickCount = 0;
        BallCount = 1;
        
        brickStr = BrickStrs[StageLevel].Replace("\n", "");
        if(brickStr[0] == 'R')
        {
            MakeRandBrick(brickStr[0] - '0');
        }
        else MakeBrick();
    }
   
    public void MakeBrick()
    {
        int row = 7;
        int col;

        bricks = new GameObject("bricks");

        for (int i = 0; i < brickStr.Length; i++) 
        { 
            col = i % 7;
            if(col == 0) row--;
            
            if(brickStr[i] == '0') continue;
            else BrickCount++;
            
            GameObject newBrick = Instantiate(brick, new Vector3(col * xGap + xOffset, row * yGap + yOffset), Quaternion.identity);
            newBrick.transform.SetParent(bricks.transform, true);
            newBrick.GetComponent<Brick>().SettingBrick(brickStr[i] - '0');
        }
    }
    
    public void MakeRandBrick(int totalRow)
    {
        int brinkNum = 7 * totalRow;
        int brickType;

        int row = 7;
        int col;

        bricks = new GameObject("bricks");

        for(int i = 0; i < brinkNum; i++)
        {
            col = i % 7;
            if(col == 0) row--;

            brickType = Random.Range(0, 8);
            if(brickType == 0) continue;
            else BrickCount++;

            GameObject newBrick = Instantiate(brick, new Vector3(col * xGap + xOffset, row * yGap + yOffset), Quaternion.identity);
            newBrick.transform.SetParent(bricks.transform, true);
            newBrick.GetComponent<Brick>().SettingBrick(brickType);
        }
    }

    private void StageClear()
    {
        CheckScore();
       
        //TODO : 다음 스테이지로 넘어가기
    }

    private void EndGame()
    {
        CheckScore();
        currentScore = 0; 
    }

    private void CheckScore()
    {
        if (highestScore < currentScore)
        {
            highestScore = currentScore;
        }
    }

}
