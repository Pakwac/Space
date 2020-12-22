using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0;
    public delegate void OnFire();
    public static event OnFire onFires;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (nextFire <= 0)
            {
                nextFire += fireRate;
                onFires?.Invoke();
            }
        }
        if (nextFire > 0) nextFire -= Time.deltaTime;
    }
}
