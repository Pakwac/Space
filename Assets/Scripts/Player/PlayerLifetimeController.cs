using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifetimeController : MonoBehaviour
{
    public delegate void PlayerDeath(Transform position);
    public static event PlayerDeath playerIsDead;

    void Start()
    {
       
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerIsDead(transform);
        }
    }
}
