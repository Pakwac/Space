using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int MaxScore;
    

    Save sv = new Save();
    private string path;


    public void AssignScore(int score)
    {
        if (MaxScore < score)
        {
            MaxScore = score;
        }
    }
    private void Start()
    {
        ScoreCounter.MaxScore += AssignScore;

#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        //if (File.Exists(path))
        //{
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            Debug.Log("Максимальное количество очков " + sv.MaxScore);
        //}
        MaxScore = sv.MaxScore;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

   


}

[Serializable]
public class Save
{
   public int MaxScore;
}
