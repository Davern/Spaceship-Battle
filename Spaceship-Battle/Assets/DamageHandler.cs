using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    float invuln = 0;

    int layer;

    void Start()
    {
        layer = gameObject.layer;
    }
    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (invuln <= 0)
        {
            health--;

            invuln = 3f;

            gameObject.layer = 8;
        }

    }

    void Update()
    {
        invuln -= Time.deltaTime;

        if (invuln <= 0)
        {
            gameObject.layer = layer;
        }

        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}
