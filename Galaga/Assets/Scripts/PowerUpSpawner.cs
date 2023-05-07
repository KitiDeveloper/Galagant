using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject Spawns;
    public GameObject Spawns2;
    public GameObject Spawns3;

    float maxSpawnRateInSeconds = 10f;

    float nextSpawn = 0f;
    float shouldISpawn = 0f;

    float timer = 0f;

    private GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.Find("Player");
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= nextSpawn)
        {
            if (playerShip != null)
            {
                if (maxSpawnRateInSeconds > 3)
                {
                    maxSpawnRateInSeconds = maxSpawnRateInSeconds * 0.995f;
                }

                nextSpawn = Random.Range(3f, maxSpawnRateInSeconds);
                SpawnPowerUp();
                timer = 0f;
            }
        }
    }

    private void SpawnPowerUp()
    {
        shouldISpawn = Random.Range(0, 20);
        if (shouldISpawn < 5)
        {
            float min = -5f;

            float max = 5f;

            GameObject anEnemy = (GameObject)Instantiate(Spawns);
            anEnemy.transform.position = new Vector2(Random.Range(min, max), 6);
        }
        else if (shouldISpawn < 15)
        {
            float min = -5f;

            float max = 5f;

            GameObject anEnemy = (GameObject)Instantiate(Spawns2);
            anEnemy.transform.position = new Vector2(Random.Range(min, max), 6);
        }
        else if (shouldISpawn < 20)
        {
            float min = -5f;

            float max = 5f;

            GameObject anEnemy = (GameObject)Instantiate(Spawns3);
            anEnemy.transform.position = new Vector2(Random.Range(min, max), 6);
        }
    }
}
