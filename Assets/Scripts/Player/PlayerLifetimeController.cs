using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifetimeController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shot") || other.CompareTag("Enemy"))
        {
            var explosion = PoolManager.Instance.GetObjectFromPool(PoolType.Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.transform.rotation = Quaternion.identity;
            explosion.GetComponent<Detonator>().Explode();
            gameObject.SetActive(false);
        }
    }
}
