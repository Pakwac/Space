using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyAi : MonoBehaviour
{
    [Inject]
    PoolManager poolManager;

    [SerializeField]
    PrefabConfig config;

    [SerializeField]
    ScriptableScore scoreContainer;



    private int bulletSpeed = 100;
    float speed = 10;
    float distance;
    Camera cam;
    float x_left;
    float x_right;
    float moveX;
    Vector3 clampedPos;
    Vector3 side;
    [SerializeField]
    Transform shootPosition;



    void Start()
    {
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;

        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        x_left = leftBot.x;
        x_right = rightTop.x;
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(15);
        poolManager.ReturnToPool(gameObject, PoolType.Enemy);
    }
    IEnumerator Maneuver()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            moveX = Random.Range(-1f, 1f);
            side = Vector3.right * moveX * 50 * Time.deltaTime;
            yield return new WaitForSeconds(1f);
            moveX = 0;
            side = Vector3.zero;
        }
    }

    IEnumerator ShootingCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Shooting();
        }
    }
    void Update()
    {
        var tilt = Mathf.Clamp(moveX * 50, -50, 50);
        Vector3 forward = Vector3.back * speed * Time.deltaTime;

        transform.Translate(side + forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.x, -tilt), speed * Time.deltaTime);

        clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        transform.position = clampedPos;
        transform.position = new Vector3(clampedPos.x, 0, transform.position.z);
    }

    private void OnEnable()
    {
        StartCoroutine(Maneuver());
        StartCoroutine(LifeTime());
        StartCoroutine(ShootingCorutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            scoreContainer.score++;
            var explosion = poolManager.GetObjectFromPool(PoolType.Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.transform.rotation = Quaternion.identity;
            poolManager.ReturnToPool(gameObject, PoolType.Enemy);
        }
    }
  

    void Shooting()
    {
        var bullet = poolManager.GetObjectFromPool(PoolType.Bullet);
        bullet.transform.position = shootPosition.transform.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.back * bulletSpeed;

        foreach (Transform transform in bullet.transform.GetComponentsInChildren<Transform>(true))
        {
            transform.gameObject.layer = 8;
        }

    }

    public class Facktory : PlaceholderFactory<EnemyAi> { }
}
