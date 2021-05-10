using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    float bulletSpeed = 7f;
    int layer;

    void Start()
    {
        layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (layer == 6)
        {
            Vector3 pos = transform.position;

            pos += new Vector3(0, bulletSpeed * Time.deltaTime, 0);

            transform.position = pos;
        }
        if (layer == 7)
        {
            Vector3 pos = transform.position;

            pos -= new Vector3(0, bulletSpeed * Time.deltaTime, 0);

            transform.position = pos;
        }
    }
}
