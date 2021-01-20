using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    [SerializeField]
    ScriptableScore scoreConteiner;

    public int MaxScore;
    
    public void Update()
    {
        if ( MaxScore < scoreConteiner.score )
        {
            MaxScore = scoreConteiner.score;
        }

    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            MaxScore = PlayerPrefs.GetInt("MaxScore", MaxScore);
        }
        else MaxScore = 0;
    }

//#if UNITY_ANDROID && !UNITY_EDITOR
//    private void OnApplicationPause(bool pause)
//    {
//        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
//    }
//#endif
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);
        scoreConteiner.score = 0;
    }
}

