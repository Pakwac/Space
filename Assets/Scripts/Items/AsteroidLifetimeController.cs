using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AsteroidLifetimeController : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;
    [SerializeField]
    ScriptableScore scoreConteiner;
    [SerializeField]
    PrefabConfig config;
    public GameObject prefab;
    Rigidbody rb;
    float lifeTime = 25;
    const int defaultScore = 0;



    private void Awake()
    {
        prefab = Instantiate(config.prefab[UnityEngine.Random.Range(0, config.prefab.Count)], gameObject.transform);

        if (GetComponent<Rigidbody>() == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
        else
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    private void Start()
    {
        PlayerLifetimeController.onDead += PlayerIsDaed;
    }

    void OnEnable()
    {
        rb.velocity = Vector3.back * UnityEngine.Random.Range(5, 10);
        rb.angularVelocity = UnityEngine.Random.insideUnitSphere;
        rb.transform.rotation = UnityEngine.Random.rotation;
        StartCoroutine(LifeTymeCycle());

    }
    IEnumerator LifeTymeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        poolManager.ReturnToPool(gameObject, PoolType.Asteroid);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        scoreConteiner.score++;
        var explosion = poolManager.GetObjectFromPool(PoolType.Explosion);
        explosion.transform.position = gameObject.transform.position;
        explosion.transform.rotation = Quaternion.identity;
        poolManager.ReturnToPool(gameObject, PoolType.Asteroid);
    }
   
    void PlayerIsDaed()
    {
        scoreConteiner.score = defaultScore;
    }
    public class Facktory : PlaceholderFactory<AsteroidLifetimeController> { }
}
