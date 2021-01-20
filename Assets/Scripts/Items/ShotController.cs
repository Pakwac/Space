using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    PoolManager poolManager;

    private void Start()
    {
        poolManager = PoolManager.Instance;
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
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            poolManager.ReturnToPool(gameObject, PoolType.Bullet);
        }
    }
}
