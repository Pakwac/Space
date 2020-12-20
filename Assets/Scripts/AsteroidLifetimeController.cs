using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLifetimeController : MonoBehaviour
{

    [SerializeField]
    GameObject explosion;

    public delegate void OnDemage(Transform currentAsteroidOnDamage);
    public static event OnDemage OnDamageAsteroid;

    float lifeTime = 15;


    IEnumerator LifeTymeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDamageAsteroid?.Invoke(transform);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("LifeTymeCycle");
    }
}
