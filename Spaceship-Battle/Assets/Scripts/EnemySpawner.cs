using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float enemyRate = 3;
    float nextEnemy = 1;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;

            Vector3 offset = new Vector3(0, 7, 0);

            float screenRatio = (float)Screen.width / (float)Screen.height;

            float widthOrtho = Camera.main.orthographicSize * screenRatio;

            offset.x = Random.Range(-widthOrtho, widthOrtho);

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);

        }
    }
}
