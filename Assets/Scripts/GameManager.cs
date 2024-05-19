using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int BrickCount { get; set; }
    private int ballCount { get; set; }

    public int StageLevel { get; set; } = 1;

    [TextArea]
    [SerializeField] private string[] BrickStrs;
    
    [SerializeField] private GameObject brick;

    //Offset: 위치 조정 위한 값, Gap: 벽돌 사이 간격
    //xOffset: -6.3 yOffset: 0.6 xGap: 2.1 yGap: 0.55
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float xGap;
    [SerializeField] private float yGap;

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
        MakeBrick();
    }

    public void MakeBrick()
    {
        string BrickStr = BrickStrs[StageLevel].Replace("\n", "");
        int row = 7;
        int col;

        Debug.Log(BrickStr.Length);

        for (int i = 0; i < BrickStr.Length; i++) 
        { 
            col = i % 7;
            if(col == 0) row--;
            
            if(BrickStr[i] == '0') continue;
            else BrickCount++;
            
            GameObject newBrick = Instantiate(brick, new Vector3(col * xGap + xOffset, row * yGap + yOffset), Quaternion.identity);
            newBrick.GetComponent<Brick>().SettingBrick(BrickStr[i] - '0');
        }
    }

    private void StageClear()
    {
        if (BrickCount == 0)
        {
            //스테이지 클리어
        }
    }

    private void EndGame()
    {
        if (ballCount <= 0)
        {
            //게임종료
        }
    }


}
