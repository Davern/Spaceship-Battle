using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPreFab;
    GameObject playerInstance;
    public static int numLives;

    float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        numLives = 4;
        Time.timeScale = 1;
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }

    void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        Vector3 pos = transform.position;
        pos += new Vector3(0, -Camera.main.orthographicSize, 0);
        playerInstance = (GameObject)Instantiate(playerPreFab, pos, Quaternion.identity);
        playerInstance.name = "PlayerShip";
    }

    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
        }
        else
        {
            Time.timeScale = 0;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over! Score: " + EnemySpawner.score);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 70, 30), "Try Again"))
            {
                EnemySpawner.score = 0;
                PlayerShooting.ammoCount = 10;
                EnemySpawner.enemiesDestroyed = 0;
                SceneManager.LoadSceneAsync(0);
            };
        }
    }
}
