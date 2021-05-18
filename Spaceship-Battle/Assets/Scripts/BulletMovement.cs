using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    float bulletSpeed = 12f;
    int layer;

    void Start()
    {
        layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (layer == 9)
        {
            Vector3 pos = transform.position;

            pos += new Vector3(0, bulletSpeed * Time.deltaTime, 0);

            transform.position = pos;
        }
        if (layer == 10)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(0, Time.deltaTime * bulletSpeed, 0);

            Quaternion rot = transform.rotation;

            pos += rot * velocity;

            transform.position = pos;
        }
    }
}
