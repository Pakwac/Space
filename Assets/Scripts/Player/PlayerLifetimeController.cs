using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerLifetimeController : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;
    public static System.Action onDead;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 10)
        {
            var explosion = poolManager.GetObjectFromPool(PoolType.Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.transform.rotation = Quaternion.identity;
            onDead?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
