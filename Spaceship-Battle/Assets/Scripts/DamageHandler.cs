using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    float invuln = 0;

    int layer;

    SpriteRenderer spriteRenderer;

    public GameObject powerUpPreFab;



    void Start()
    {
        layer = gameObject.layer;

        if (layer == 8)
        {
            invuln = PlayerSpawner.invulnTimer;
        }

        // Note: this only gets the renderer on the parent object
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.Log("Object '" + gameObject.name + "' has no sprite renderer.");
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "PowerUp01")
        {
            health--;

            if (invuln <= 0)
            {
                invuln = 3f;

                gameObject.layer = 8;
            }
        }
    }

    void Update()
    {
        invuln -= Time.deltaTime;

        if (invuln <= 0)
        {
            if (gameObject.name == "PlayerShip")
            {
                gameObject.layer = 6;
            }
            else
            {
                gameObject.layer = layer;
            }
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
        }
        else
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }

        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {

        if (gameObject.name == "Enemy01")
        {
            EnemySpawner.score += 3;
            EnemySpawner.enemiesDestroyed++;
            FindObjectOfType<AudioManager>().Play("Explosion");
            if (!PlayerSpawner.poweredUp)
            {
                if (Random.Range(1, 11) == 5)
                {
                    GameObject go = Instantiate(powerUpPreFab, gameObject.transform.position, Quaternion.identity);
                    go.name = "PowerUp01";
                }
            }
        }
        if (gameObject.name == "Debris01" || gameObject.name == "Debris02" || gameObject.name == "Debris03")
        {
            EnemySpawner.score++;
            FindObjectOfType<AudioManager>().Play("DebrisExplosion");
            if (!PlayerSpawner.poweredUp)
            {
                if (Random.Range(1, 11) == 5)
                {
                    GameObject go = Instantiate(powerUpPreFab, gameObject.transform.position, Quaternion.identity);
                    go.name = "PowerUp01";
                }
            }
        }
        if (gameObject.name == "PlayerShip")
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
        }
        Destroy(gameObject);
    }
}
