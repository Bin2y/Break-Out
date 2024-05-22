using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = true;
    public bool isClear = false;
    public bool isFail = false;

    public static int StageLevel { get; set; } = 1;

    public int[] highestScores = new int[8];

    public int maxScore = 0;
    public int currentScore = 0;

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

    private void Update()
    {
        if (!isGameOver)
        {
            CheckScore();

            if (BrickCount == 0)
            {
                StageClear();
            }
            if (BallCount == 0)
            {
                EndGame();
            }
        }
    }

    public void StageInit(GameObject bricks)
    {
        BrickCount = 0;
        BallCount = 1;

        isGameOver = false;
        isClear = false;
        isFail = false;

        maxScore = 0;
        currentScore = 0;

        brickStr = BrickStrs[StageLevel].Replace("\n", "");
        if (brickStr[0] == 'R') MakeRandBrick(bricks, brickStr[1] - '0');
        else MakeBrick(bricks);
    }

    public void MakeBrick(GameObject bricks)
    {
        int row = 7;
        int col;

        for (int i = 0; i < brickStr.Length; i++)
        {
            col = i % 7;
            if (col == 0) row--;

            if (brickStr[i] == '0') continue;
            else
            {
                BrickCount++;
                maxScore += 50;
            }

            GameObject newBrick = Instantiate(brick, new Vector3(col * xGap + xOffset, row * yGap + yOffset), Quaternion.identity, bricks.transform);
            newBrick.GetComponent<Brick>().SettingBrick(brickStr[i] - '0');
        }
    }

    public void MakeRandBrick(GameObject bricks, int totalRow)
    {
        int brinkNum = 7 * totalRow;
        int brickType;

        int row = 7;
        int col;

        for (int i = 0; i < brinkNum; i++)
        {
            col = i % 7;
            if (col == 0) row--;

            brickType = Random.Range(0, 8);
            if (brickType == 0) continue;
            else
            {
                BrickCount++;
                maxScore += 50;
            }

            GameObject newBrick = Instantiate(brick, new Vector3(col * xGap + xOffset, row * yGap + yOffset), Quaternion.identity, bricks.transform);
            newBrick.GetComponent<Brick>().SettingBrick(brickType);
        }
    }

    private void StageClear()
    {
        isGameOver = true;
        isClear = true;
    }

    private void EndGame()
    {
        isGameOver = true;
        isFail = true;  
    }

    private void CheckScore()
    {
        if (highestScores[StageLevel] < currentScore) highestScores[StageLevel] = currentScore;
    }
}
