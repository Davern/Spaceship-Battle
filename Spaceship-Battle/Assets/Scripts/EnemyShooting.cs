using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPreFab;
    public float fireDelay = 0.5f;
    float cooldownTime = 0;

    Transform player;

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;

        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
        {
            return;
        }

        Vector3 playerPos = player.position;

        bool playerInSight = (math.floor(playerPos.x) == math.floor(transform.position.x));


        if (cooldownTime <= 0 && playerInSight)
        {
            cooldownTime = fireDelay;

            Vector3 pos = transform.position;

            float newY = (float)pos.y - 0.65f;

            Vector3 newPos = new Vector3(pos.x, newY, pos.z);

            Instantiate(bulletPreFab, newPos, transform.rotation);
        }
    }
}
