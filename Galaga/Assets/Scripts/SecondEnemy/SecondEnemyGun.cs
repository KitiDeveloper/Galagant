using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyGun : MonoBehaviour
{
    public GameObject enemyBullet;

    void Start()
    {
        //Invoke("FireEnemyBullet", 0.5f);
        Invoke("FireSecondEnemyBullet", 0.6f);
        Invoke("FireThirdEnemyBullet", 0.7f);
        //Invoke("FireEnemyBullet", 1f);
        //Invoke("FireEnemyBullet", 1.5f);
        //Invoke("FireEnemyBullet", 2f);
        //Invoke("FireEnemyBullet", 2.5f);
        Invoke("FireSecondEnemyBullet", 2.6f);
        Invoke("FireThirdEnemyBullet", 2.7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

            GameObject shootAudio = GameObject.Find("AlienShootAudio");
            AudioSource audioSource = shootAudio.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.6f, 1.4f);
            audioSource.volume = Random.Range(0f, 0.15f);
            audioSource.Play();
        }
    }

    void FireSecondEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = transform.position;

            float yDir = playerShip.transform.position.y - bullet.transform.position.y;
            float xDir = (playerShip.transform.position.y - bullet.transform.position.y) * -.5f;

            Vector2 direction = new Vector2(xDir, yDir);

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

            GameObject shootAudio = GameObject.Find("AlienShootAudio");
            AudioSource audioSource = shootAudio.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.6f, 1.4f);
            audioSource.volume = Random.Range(0f, 0.15f);
            audioSource.Play();
        }
    }

    void FireThirdEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = transform.position;

            float yDir = playerShip.transform.position.y - bullet.transform.position.y;
            float xDir = (playerShip.transform.position.y - bullet.transform.position.y) * .5f;

            Vector2 direction = new Vector2(xDir, yDir);

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

            GameObject shootAudio = GameObject.Find("AlienShootAudio");
            AudioSource audioSource = shootAudio.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.6f, 1.4f);
            audioSource.volume = Random.Range(0f, 0.15f);
            audioSource.Play();
        }
    }
}
