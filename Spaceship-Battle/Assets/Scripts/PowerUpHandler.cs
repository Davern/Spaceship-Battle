using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{

    void OnTriggerEnter2D()
    {
        if (gameObject.name == "PowerUp01")
        {
            PlayerSpawner.poweredUp = true;
            PlayerShooting.ammoCount = 100;
            PlayerShooting.fireDelay = 0.1f;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
