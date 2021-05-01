using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float leftConst = Screen.width;
    float rightConst = Screen.width;
    float bottomConst = Screen.height;
    float topConst = Screen.height;

    float buffer = 1.0f;
    Camera cam;
    float distanceZ;

    private void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConst = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConst = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConst = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConst = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    private void FixedUpdate()
    {
        if(transform.position.x < leftConst - buffer)
        {
            transform.position = new Vector3(rightConst - 0.10f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConst)
        {
            transform.position = new Vector3(leftConst + 0.10f, transform.position.y, transform.position.z);
        }

        //if (transform.position.x < rightConst - buffer)
        //{
        //    transform.position = new Vector3(leftConst - 0.10f, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x > leftConst)
        //{
        //    transform.position = new Vector3(leftConst, transform.position.y, transform.position.z);
        //}
    }
}
