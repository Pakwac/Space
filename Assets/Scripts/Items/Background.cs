using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float scrollSpeed;
    [SerializeField]
    float tileSize;

    public int localSize = 10;

    private void Start()
    {
        tileSize = GetComponent<SpriteRenderer>().size.y * localSize;
    }
    private void Update()
    {
        scrollSpeed += speed * Time.deltaTime;
        scrollSpeed = Mathf.Repeat(scrollSpeed, tileSize);
        transform.position = new Vector3(0, -10, scrollSpeed);  // not best way, but it first version. Fix it later
    }

}
