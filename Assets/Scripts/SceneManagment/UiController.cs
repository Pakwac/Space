using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    GameObject reloadButtom;
    [SerializeField]
    GameObject ExitButtom;
    [SerializeField]
    GameObject player;

    
    void Start()
    {
        reloadButtom.SetActive(false);
        ExitButtom.SetActive(false);
        PlayerLifetimeController.onDead += PlayerIsDead;
    }


    void PlayerIsDead()
    {
        if (player != null)
        {
            reloadButtom.SetActive(true);
            ExitButtom.SetActive(true);
        }
    }
}
