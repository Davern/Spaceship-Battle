using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    float timer = 2.5f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.name == "Bullet01" && gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
