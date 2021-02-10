using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AsteroidSpawnManager : MonoBehaviour
{
    Camera cam;
    [Inject]
    PoolManager poolManager;

    float x_left;
    float x_right;
    float z_top;
    float z_bot;
    float distance;
    
    IEnumerator SpawnCourutine()
    {
        while (true)
        {
            var i = Random.Range(1, 3);
            yield return new WaitForSeconds(i);
            SpawnAsteroid();
        }
    }
  
    void Start()
    {
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;

        StartCoroutine(SpawnCourutine());
    }

    
    void SpawnAsteroid()
    {
        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0));
        var rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1));

        x_left = leftBot.x;
        x_right = rightTop.x;
        z_top = rightTop.z;
        z_bot = leftBot.z;

        Vector3 clampedPos = transform.position;
        clampedPos.z = 1.1f;
        float temp = Random.value;
        Vector3 asteroidPosition = cam.ViewportToWorldPoint(new Vector3(temp, clampedPos.z, distance));

        var asteroid = poolManager.GetObjectFromPool(PoolType.Asteroid);
        asteroid.transform.position = asteroidPosition;
    }



    
}
