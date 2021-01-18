using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0;

    [SerializeField]
    public GameObject shootPosition;

    [SerializeField]
    int typeFire = 0;// это  поле нужно для дальнейшей реализации системы разного оружия
    
    PoolManager poolManager;


    private int bulletSpeed = 100;

    private void Start()
    {
        poolManager = PoolManager.Instance;
    }

    void Update()
    {
            if (nextFire <= 0)
            {
                nextFire += fireRate;
                var bullet = poolManager.GetObjectFromPool(PoolType.Bullet);
                bullet.transform.position = shootPosition.transform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                bullet.layer = 9;
        }
        if (nextFire > 0) nextFire -= Time.deltaTime;
    }
}
