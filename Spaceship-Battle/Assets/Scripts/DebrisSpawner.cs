using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public GameObject debrisPrefab;

    float debrisRate = 3;
    float nextDebris = 1;

    // Update is called once per frame
    void Update()
    {
        nextDebris -= Time.deltaTime;

        if (nextDebris <= 0)
        {
            nextDebris = 0.95f * debrisRate;

            Vector3 offset = new Vector3(0, 7, 0);

            float screenRatio = (float)Screen.width / (float)Screen.height;

            float widthOrtho = Camera.main.orthographicSize * screenRatio;

            offset.x = Random.Range(-widthOrtho, widthOrtho);

            GameObject go = Instantiate(debrisPrefab, transform.position + offset, Quaternion.identity);

            go.name = "Debris01";
        }
    }
}
