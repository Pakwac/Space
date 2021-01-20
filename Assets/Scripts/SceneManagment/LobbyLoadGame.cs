using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyLoadGame : MonoBehaviour
{
    AsyncOperation level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.LoadSceneAsync(1);
        level.allowSceneActivation = false;
    }

    public void StartGame()
    {
        level.allowSceneActivation = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
