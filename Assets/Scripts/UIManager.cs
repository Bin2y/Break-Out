using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    
   
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowScore()
    {
        currentScoreText.text = "Current Score : " + GameManager.instance.currentScore;
        highestScoreText.text = "highest Score : " + GameManager.instance.highestScore;
    }
}
