using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisMovement : MonoBehaviour
{
    Transform player;
    public float maxSpeed = 6f;

    float randomSpeed;
    // Start is called before the first frame update
    void Start()
    {
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

        randomSpeed = Random.Range(3f, 9f);
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Time.deltaTime * randomSpeed, 0);

        Quaternion rot = transform.rotation;

        pos += rot * velocity;

        transform.position = pos;

        if (transform.position.y + 1 < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
