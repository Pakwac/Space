 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnManager : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;

    Camera cam;

    float x_left;
    float x_right;
    float z_top;
    float z_bot;
    float distance;

    [SerializeField]
    float waveTime;
    [SerializeField]
    float spawnTime;

    IEnumerator SpawnCourutine()
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
                SpawnEnemy();

            }
            yield return new WaitForSeconds(waveTime);
        }
    }
   
    void Start()
    {
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;

        StartCoroutine(SpawnCourutine());
    }

    void SpawnEnemy()
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
        Vector3 enemyPosition = cam.ViewportToWorldPoint(new Vector3(temp, clampedPos.z, distance));

        var enemy = poolManager.GetObjectFromPool(PoolType.Enemy);
        enemy.transform.position = enemyPosition;
        enemy.transform.rotation = Quaternion.identity;
    }
}
