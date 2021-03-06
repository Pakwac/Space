﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public delegate void OnDead(Transform position);
    public static event OnDead OnDeath;
    public delegate void OnShoot(Transform position, Vector3 speed, string tag);
    public static event OnShoot Shoot;



    float speed = 10;
    Vector3 startPosition;
    float distance;
    Camera cam;
    float x_left;
    float x_right;
    float z_top;
    float z_bot;
    float moveX;
    Rigidbody rb;
    Vector3 clampedPos;
    Vector3 side;
    [SerializeField]
    Transform shootPosition;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;
        
        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        x_left = leftBot.x;
        x_right = rightTop.x;
        z_top = rightTop.z;
        z_bot = leftBot.z;

        
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(15);
        OnDeath(transform);
    }
    IEnumerator Maneuver()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            moveX = Random.Range(-1f,1f);
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
        if (other.CompareTag("Player"))
        {
            OnDeath(transform);
        }
    }

    void Shooting()
    {
        Shoot(shootPosition, Vector3.back * 100, "Enemy");
    }
}
