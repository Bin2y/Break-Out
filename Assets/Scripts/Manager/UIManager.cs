using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private GameObject canvas;
    public ScoreBoard scoreBoard { get; private set; }
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
        canvas = GameObject.Find("Canvas");
        scoreBoard = canvas.GetComponent<ScoreBoard>();
    }
}
