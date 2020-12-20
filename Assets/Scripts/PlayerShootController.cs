using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    Transform shootSpawn;
    [SerializeField]
    GameObject shot;

    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0;

    List<GameObject> shots = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            var currentShot = Instantiate<GameObject>(shot);
            currentShot.SetActive(false);
            shots.Add(currentShot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFire <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                nextFire += fireRate;
                if (shots.Exists(e => e.activeSelf == false))
                {
                    var currentShot = shots.Find(x => x.activeSelf == false);
                    currentShot.transform.position = shootSpawn.position;
                    currentShot.SetActive(true);
                }
                else
                {
                    var currentShot = Instantiate<GameObject>(shot);
                    currentShot.transform.position = shootSpawn.position;
                    currentShot.SetActive(true);
                    shots.Add(currentShot);
                }
            }
        }
        if (nextFire > 0) nextFire -= Time.deltaTime;
    }
}
