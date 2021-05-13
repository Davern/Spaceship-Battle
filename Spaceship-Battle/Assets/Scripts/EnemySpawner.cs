using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float enemyRate = 3;
    float nextEnemy = 1;

    public float remainingEnemies = 15;

    public static int enemiesDestroyed = 0;

    public static int score = 0;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;

            Vector3 offset = new Vector3(0, 14, 0);

            float screenRatio = (float)Screen.width / (float)Screen.height;

            float widthOrtho = Camera.main.orthographicSize * screenRatio;

            offset.x = Random.Range(-widthOrtho, widthOrtho);

            GameObject go = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);

            go.name = "Enemy01";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 100, 50), "Score: " + score);
        if (enemiesDestroyed < remainingEnemies)
        {
            GUI.Label(new Rect(0, 60, 100, 50), "Enemies destroyed: " + enemiesDestroyed + "/" + remainingEnemies);
        }
        else
        {
            Time.timeScale = 0;
            GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Level Completed! Click here to advance to the next level");
        }
    }
}
