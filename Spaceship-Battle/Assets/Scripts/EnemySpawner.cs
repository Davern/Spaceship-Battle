using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float enemyRate = 3;
    float nextEnemy = 1;

    public static int score = 0;

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

            GameObject go = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);

            go.name = "Enemy01";
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(675, 0, 100, 50), "Score: " + score);
    }
}
