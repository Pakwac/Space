using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerShootController : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;

    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0;

    [SerializeField]
    public GameObject shootPosition;

    private int bulletSpeed = 100;

    void Update()
    {
        if (nextFire <= 0)
        {
            nextFire += fireRate;
            var bullet = poolManager.GetObjectFromPool(PoolType.Bullet);
           
            bullet.transform.position = shootPosition.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.GetComponentInChildren<Rigidbody>().velocity = Vector3.forward * bulletSpeed;

            foreach (Transform transform in bullet.transform.GetComponentsInChildren<Transform>(true))
            {
                transform.gameObject.layer = 9;
            }

        }
        if (nextFire > 0) nextFire -= Time.deltaTime;
    }
}
