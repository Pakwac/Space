using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    ScriptableScore scoreContainer;

    public Text scoreText;
    const int startScore = 0;

    void Start()
    {
        PlayerLifetimeController.onDead += OnPlayerDead;
        scoreText = GetComponent<Text>();
        scoreText.text = "SCORE " + startScore.ToString();
        scoreContainer.score = startScore;
    }

    public void Update()
    {
        scoreText.text = "SCORE " + scoreContainer.score.ToString();
    }

    void OnPlayerDead()
    {
        scoreContainer.score = 0;
    }

}
