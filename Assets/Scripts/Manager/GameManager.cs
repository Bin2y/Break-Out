using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentScore = 0;
    public int highestScore = 0;

    public int BrickCount { get; set; }
    public int ballCount { get; set; }

    [SerializeField] private int stageLevel;

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
        if (BrickCount == 0)
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
        BrickCount = 0;
        ballCount = 1;
        //MakeBrick();
        MakeRandBrick(3);
        //TODO : 스테이지별로 벽돌갯수랑 ball갯수 등록
    }
   

    public void MakeBrick()
    {
        string brickStr = BrickStrs[stageLevel].Replace("\n", "");
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
