using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifetimeController : MonoBehaviour
{
    public static System.Action onDead;
    public bool isAlive;

    private void Start()
    {
         isAlive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot") || other.CompareTag("Enemy"))
        {
            var explosion = PoolManager.Instance.GetObjectFromPool(PoolType.Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.transform.rotation = Quaternion.identity;
            onDead?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
