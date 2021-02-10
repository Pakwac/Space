using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Explosion : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;
    [SerializeField]
    PrefabConfig config;
    GameObject prefab;

    private void Awake()
    {
        if (prefab == null)
        {
            prefab = Instantiate(config.prefab[UnityEngine.Random.Range(0, config.prefab.Count)], gameObject.transform);
            prefab.SetActive(false);
        }
    }

    private void OnEnable()
    {
        prefab.SetActive(true);
    }

    private void Update()
    {
        if (!prefab.GetComponent<ParticleSystem>().isPlaying)
        {
            prefab.SetActive(false);
            poolManager.ReturnToPool(gameObject, PoolType.Explosion);
        }

    }
   
    public class Facktory : PlaceholderFactory<Explosion> { }
}
