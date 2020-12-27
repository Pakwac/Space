using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int MaxScore;
    
    public int AssignScore(int score)
    {
        if (MaxScore < score)
        {
            MaxScore = score;
        }

        return score;
    }
    private void Start()
    {
        ScoreCounter.MaxScore += AssignScore;

        if (PlayerPrefs.HasKey("MaxScore"))
        {
            MaxScore = PlayerPrefs.GetInt("MaxScore", MaxScore);
        }
        else MaxScore = 0;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);
    }
}

