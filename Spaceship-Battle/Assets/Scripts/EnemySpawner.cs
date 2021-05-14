using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float enemyRate = 3;
    public float nextEnemy = 1;

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
        GUI.Label(new Rect(5, 20, 100, 50), "Score: " + score);
        GUI.Label(new Rect(Screen.width - 50, 0, 100, 50), SceneManager.GetActiveScene().name);
        if (enemiesDestroyed < remainingEnemies)
        {
            GUI.Label(new Rect(5, 60, 100, 50), "Enemies Destroyed: " + enemiesDestroyed + "/" + remainingEnemies);
        }
        else
        {
            Time.timeScale = 0;
            if (SceneManager.GetActiveScene().name == "Level05")
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "You Win! Your Score was: " + EnemySpawner.score);
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 70, 30), "Restart"))
                {
                    EnemySpawner.score = 0;
                    PlayerShooting.ammoCount = 10;
                    EnemySpawner.enemiesDestroyed = 0;
                    SceneManager.LoadSceneAsync(0);
                }
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Next Level"))
                {
                    PlayerShooting.ammoCount = 10;
                    EnemySpawner.enemiesDestroyed = 0;
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
