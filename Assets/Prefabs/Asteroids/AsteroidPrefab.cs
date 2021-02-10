using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidPrefab : MonoBehaviour
{
    public static Action OnDamage;
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            OnDamage?.Invoke();
        }
    }
}
