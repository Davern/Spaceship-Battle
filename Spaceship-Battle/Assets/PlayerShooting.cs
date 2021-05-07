using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float fireDelay = 0.25f;
    float cooldownTime = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTime <= 0)
        {
            Debug.Log("Pew!");
            cooldownTime = fireDelay;
        }
    }
}
