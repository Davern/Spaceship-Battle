using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    float maxSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos -= new Vector3(0, Time.deltaTime * maxSpeed, 0);

        transform.position = pos;

        if (transform.position.y + 1 < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
