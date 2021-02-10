using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    GameObject joystic;
    [SerializeField]
    List<GameObject> objectsToHide;
    [SerializeField]
    GameObject player;

    
    void Start()
    {
        foreach (var item in objectsToHide)
        {
            item.SetActive(false);
        }
        joystic.SetActive(true);
        PlayerLifetimeController.onDead += PlayerIsDead;
    }

    void PlayerIsDead()
    {
        if (player != null)
        {
            foreach (var item in objectsToHide)
            {
                item.SetActive(true);
            }
            joystic.SetActive(false);
        }
    }
}
