using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLifetimeController : MonoBehaviour
{
    Detonator detonator;
    float durationOfLifetime = 3;

    public delegate void ExplosionLifeTime(Transform position);
    public static event ExplosionLifeTime explosionLifeTime;
    IEnumerator LifeTimeCycle()
    {
        yield return new WaitForSeconds(durationOfLifetime);
        explosionLifeTime?.Invoke(transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        detonator = GetComponent<Detonator>();
    }

    private void OnEnable()
    {
        StartCoroutine("LifeTimeCycle");
        detonator.Explode();
    }
}
