﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    public delegate int Score(int score);
    public static event Score MaxScore;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        EnemyAi.OnDeath += ScoreCounting;
        AsteroidLifetimeController.OnDamageAsteroid += ScoreCounting;

        score = 0;
        scoreText.text = score.ToString();
    }

    
    public void ScoreCounting(Transform position)
    {
        score++;
        MaxScore(score);
        scoreText.text = score.ToString();
    }
}
