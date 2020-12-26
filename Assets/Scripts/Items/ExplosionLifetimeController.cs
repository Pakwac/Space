using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLifetimeController : MonoBehaviour
{
    float durationOfLifetime = 3;

    public delegate void ExplosionLifeTime(Transform position);
    public static event ExplosionLifeTime explosionLifeTime;
    IEnumerator LifeTimeCycle()
    {
        yield return new WaitForSeconds(durationOfLifetime);
        explosionLifeTime?.Invoke(transform);
    }
    private void OnEnable()
    {
        StartCoroutine("LifeTimeCycle");
    }
}
