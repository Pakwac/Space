using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    ScriptableScore scoreConteiner;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = scoreConteiner.score.ToString();
    }

    public void Update()
    {
        scoreText.text = scoreConteiner.score.ToString();
    }
}
