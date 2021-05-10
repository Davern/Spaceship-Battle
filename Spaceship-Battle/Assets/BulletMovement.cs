using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    float bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos += new Vector3(0, bulletSpeed * Time.deltaTime, 0);

        transform.position = pos;
    }
}
