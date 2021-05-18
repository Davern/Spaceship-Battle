using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPreFab;
    public static float fireDelay;
    float cooldownTime = 0;

    public static int ammoCount;

    float reloadTime = 1.5f;


    void Start()
    {
        ammoCount = 10;
        fireDelay = 0.25f;
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTime <= 0 && ammoCount > 0)
        {
            cooldownTime = fireDelay;

            ammoCount--;

            Vector3 pos = transform.position;

            float newY = (float)pos.y + 0.65f;

            Vector3 newPos = new Vector3(pos.x, newY, pos.z);

            GameObject go = Instantiate(bulletPreFab, newPos, transform.rotation);

            go.name = "Bullet01";

            FindObjectOfType<AudioManager>().Play("Laser");
        }
        if (ammoCount <= 0)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                ammoCount = 10;
                reloadTime = 1.5f;
            }
        }
        if (Input.GetButton("Reload"))
        {
            ammoCount = 0;
            FindObjectOfType<AudioManager>().Play("Reload");
        }
    }

    void OnGUI()
    {
        if (ammoCount > 0)
        {
            GUI.Label(new Rect(5, 40, 100, 50), "Ammo: " + ammoCount);
        }
        else
        {
            GUI.Label(new Rect(5, 40, 100, 50), "RELOADING...");
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "RELOADING...");
        }

    }
}
