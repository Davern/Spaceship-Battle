using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    float invuln = 0;

    int layer;

    SpriteRenderer spriteRenderer;



    void Start()
    {
        layer = gameObject.layer;

        // Note: this only gets the renderer on the parent object
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.Log("Object '" + gameObject.name + "' has no sprite renderer.");
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        health--;

        if (invuln <= 0)
        {
            invuln = 3f;

            gameObject.layer = 8;
        }

    }

    void Update()
    {
        invuln -= Time.deltaTime;

        if (invuln <= 0)
        {
            gameObject.layer = layer;
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
        }
        if (gameObject.name == "Debris01" || gameObject.name == "Debris02" || gameObject.name == "Debris03")
        {
            EnemySpawner.score++;
        }
        Destroy(gameObject);
    }
}
