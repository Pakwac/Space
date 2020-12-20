using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float speed = 50;
    Rigidbody rb;
    Vector3 currenSpeed;
    void Start()
    {
        currenSpeed = Vector3.forward * speed;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       rb.velocity = currenSpeed;
    }
    private void OnEnable()
    {
        StartCoroutine("Ilifetime");
    }
    private IEnumerator Ilifetime()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
