using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextStage()
    {
        GameManager.StageLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PreviousStage()
    {
        if(GameManager.StageLevel == 1) return;

        GameManager.StageLevel--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
