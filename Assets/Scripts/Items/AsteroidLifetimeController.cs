using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLifetimeController : MonoBehaviour
{
    PoolManager poolManager;
    [SerializeField]
    ScriptableScore scoreConteiner;

    float lifeTime = 15;

    
    IEnumerator LifeTymeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        poolManager.ReturnToPool(gameObject, PoolType.Asteroid);
    }

    private void Start()
    {
        poolManager = PoolManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            scoreConteiner.score++;
            var explosion = poolManager.GetObjectFromPool(PoolType.Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.transform.rotation = Quaternion.identity;
            poolManager.ReturnToPool(gameObject, PoolType.Asteroid);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(LifeTymeCycle());
    }
}
