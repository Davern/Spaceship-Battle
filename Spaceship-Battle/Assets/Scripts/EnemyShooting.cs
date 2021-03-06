using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPreFab;
    public float fireDelay = 1f;
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


        if (cooldownTime <= 0 && playerInSight && transform.position.y < Camera.main.orthographicSize)
        {
            if (gameObject.name == "Enemy01")
            {
                cooldownTime = fireDelay;

                Vector3 pos = transform.position;

                float newY = (float)pos.y - 0.65f;

                Vector3 newPos = new Vector3(pos.x, newY, pos.z);

                Instantiate(bulletPreFab, newPos, Quaternion.Euler(0, 0, 180));
            }
            if (gameObject.name == "Enemy02")
            {
                cooldownTime = fireDelay;

                Vector3 dir = transform.position;

                float newY = (float)dir.y - 0.65f;

                Vector3 newPos = new Vector3(dir.x, newY, dir.z);

                float zAngleRight = 160;

                float zAngleLeft = 200;

                float zAngleMiddle = 180;

                Quaternion leftRot = Quaternion.Euler(0, 0, zAngleLeft);

                Quaternion rightRot = Quaternion.Euler(0, 0, zAngleRight);

                Quaternion middleRot = Quaternion.Euler(0, 0, zAngleMiddle);

                Instantiate(bulletPreFab, newPos, middleRot);

                Instantiate(bulletPreFab, newPos, leftRot);

                Instantiate(bulletPreFab, newPos, rightRot);
            }
        }
    }
}
