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

    public struct FireTupe
    {

    }
    public delegate void OnFire(Transform position, Vector3 speed, string tag);
    public static event OnFire onFires;
    void Update()
    {
        
            if (nextFire <= 0)
            {
                nextFire += fireRate;
                onFires?.Invoke(shootPosition.transform, Vector3.forward * 100, "Player");
            }
        
        if (nextFire > 0) nextFire -= Time.deltaTime;
    }
}
