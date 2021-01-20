using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class PlayerMuoveController : MonoBehaviour
{
    float speed = 100;
    [SerializeField]
    GameObject motherSheep;
    Vector3 startPosition;
    [SerializeField]
    Joystick joystick;

    float distance;
    Camera cam;
    float x_left;
    float x_right;
    float z_top;
    float z_bot;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector3 cameraToObject = transform.position - cam.transform.position;
        float distance = -Vector3.Project(cameraToObject, cam.transform.forward).y;

        startPosition = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, distance));
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //float moveY = Input.GetAxis("Vertical");
        //float moveX = Input.GetAxis("Horizontal");
        float moveY = joystick.Vertical;
        float moveX = joystick.Horizontal;

        var temp = Mathf.Clamp(moveX * 50, -50, 50);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.x, -temp), speed * Time.deltaTime);
        transform.Translate(Vector3.right * moveX * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.forward * moveY * Time.deltaTime * speed, Space.World);

        var leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        x_left = leftBot.x;
        x_right = rightTop.x;
        z_top = rightTop.z;
        z_bot = leftBot.z;

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.z = Mathf.Clamp(clampedPos.z, z_bot, z_top);
        transform.position = clampedPos;
    }
}
