using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    //[SerializeField]
    //GameObject asteroid;
    Camera cam;

    public delegate void SpawnAsteroidNeed(Vector3 spawnPosition);
    public static event SpawnAsteroidNeed NeedSpawnAsteroid;

    float x_left;
    float x_right;
    float z_top;
    float z_bot;
    float distance;
    IEnumerator SpawnCourutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            SpawnAsteroid();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;

        StartCoroutine("SpawnCourutine");
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

        NeedSpawnAsteroid?.Invoke(asteroidPosition);
    }
}
