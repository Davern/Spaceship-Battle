using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPreFab;
    public float fireDelay = 0.25f;
    float cooldownTime = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTime <= 0)
        {
            cooldownTime = fireDelay;

            Vector3 pos = transform.position;

            float newY = (float)pos.y + 0.65f;

            Vector3 newPos = new Vector3(pos.x, newY, pos.z);

            Instantiate(bulletPreFab, newPos, transform.rotation);
        }
    }
}
