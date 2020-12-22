using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMouveController : MonoBehaviour
{

    float speed;
    [SerializeField]
    float minSpeed;
    [SerializeField]
    float maxSpeed;


    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(minSpeed, maxSpeed);
        rb.angularVelocity = new Vector3(1, 1, 1) * 2;
        rb.velocity = -Vector3.forward * speed;
    }
}
