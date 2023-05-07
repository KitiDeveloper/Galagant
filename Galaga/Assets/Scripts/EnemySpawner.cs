using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Spawns;
    public GameObject Spawns2;
    public GameObject Spawns3;

    bool secondEnemy = false;
    bool thirdEnemy = false;

    float maxSpawnRateInSeconds = 4f;
    float maxBossRate = 10f;

    float nextSpawn = 0f;
    float shouldISpawn = 0f;

    float timer = 0f;

    private GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
       playerShip = GameObject.Find("Player");

        Invoke("SetSecondEnemyTrue", 80f);
        Invoke("SetThirdEnemyTrue", 160);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer >= nextSpawn)
        {
            if (playerShip != null)
            {
                if (maxSpawnRateInSeconds >= 2f)
                {
                    maxSpawnRateInSeconds = maxSpawnRateInSeconds * 0.98f;
                }
                else if (thirdEnemy)
                {
                    maxBossRate = maxBossRate * 0.99f;
                    shouldISpawn = Random.Range(0, maxBossRate);
                    if (shouldISpawn <= .5)
                    {
                        SpawnThirdEnemy();
                        SpawnSecondEnemy();
                    }
                    else if (shouldISpawn <= 1)
                    {
                        SpawnSecondEnemy();
                    }
                }
                else if (secondEnemy)
                {
                    maxBossRate = maxBossRate * 0.99f;
                    shouldISpawn = Random.Range(0, maxBossRate);
                    if (shouldISpawn <= 1)
                    {
                        SpawnSecondEnemy();
                    }
                }

                maxSpawnRateInSeconds = maxSpawnRateInSeconds * 0.9975f;

                nextSpawn = Random.Range(0.5f, maxSpawnRateInSeconds);
                SpawnEnemy();
                timer = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        float min = -5f;

        float max = 5f;

        GameObject anEnemy = (GameObject)Instantiate(Spawns);
        anEnemy.transform.position = new Vector2 (Random.Range (min, max), 6);
    }

    void SpawnSecondEnemy()
    {
        float min = -5f;

        float max = 5f;

        GameObject anEnemy = (GameObject)Instantiate(Spawns2);
        anEnemy.transform.position = new Vector2(Random.Range(min, max), 6);
    }

    void SpawnThirdEnemy()
    {
        float min = -5f;

        float max = 5f;

        GameObject anEnemy = (GameObject)Instantiate(Spawns3);
        anEnemy.transform.position = new Vector2(Random.Range(min, max), 6);
    }

    private void SetSecondEnemyTrue()
    {
        secondEnemy = true;
    }

    private void SetThirdEnemyTrue()
    {
        thirdEnemy = true;
    }
}
