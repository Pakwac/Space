using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShotController : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;

    [SerializeField]
    PrefabConfig config;
    public GameObject prefab;
    Rigidbody rb;

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

    private void OnEnable()
    {
        StartCoroutine("Ilifetime");
        
    }
    private IEnumerator Ilifetime()
    {
        yield return new WaitForSeconds(4);
        poolManager.ReturnToPool(gameObject, PoolType.Bullet);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            poolManager.ReturnToPool(gameObject, PoolType.Bullet);
        }
    }


    public class Facktory : PlaceholderFactory<ShotController> { }
}
