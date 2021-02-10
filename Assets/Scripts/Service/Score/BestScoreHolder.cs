using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreHolder : MonoBehaviour
{
    [SerializeField]
    ScriptableScore scoreContainer;
    Text bestScore;
    int score = 0;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            score = PlayerPrefs.GetInt("MaxScore");
            bestScore = GetComponent<Text>();
            bestScore.text = "BEST RESULT " + score.ToString();
        }
        else bestScore.text = "BEST RESULT " + scoreContainer.score.ToString();
    }

    private void Update()
    {
        if(score < scoreContainer.score)
        {
            bestScore.text = "BEST RESULT " + scoreContainer.score.ToString();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        SetNewScore();
    }

    private void OnApplicationQuit()
    {
        SetNewScore();
    }

    private void SetNewScore()
    {
        if (score < scoreContainer.score)
        {
            PlayerPrefs.SetInt("MaxScore", scoreContainer.score);
        }
    }
}
