using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadingSCene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
