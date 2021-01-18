using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreHolder : MonoBehaviour
{
    TextMeshProUGUI bestScore;
    int score = 0;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            score = PlayerPrefs.GetInt("MaxScore");
            bestScore = GetComponent<TextMeshProUGUI>();
            bestScore.text = "Best result " + score.ToString();
        }
        else bestScore.text = "Best result " + score.ToString();
       
    }
}
