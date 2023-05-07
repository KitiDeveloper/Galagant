using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemyGun : MonoBehaviour
{
    public GameObject enemyBullet;

    void Start()
    {
        Invoke("FireEnemyBullet", 0.2f);
        //Invoke("FireEnemyBullet", 1.5f);
        //Invoke("FireEnemyBullet", 2f);
        Invoke("FireEnemyBullet", 2f);
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

            Vector2 direction = new Vector2(0, -1);

            bullet.GetComponent<ThirdEnemyBullet>().SetDirection(direction);

            GameObject shootAudio = GameObject.Find("AlienShootAudio");
            AudioSource audioSource = shootAudio.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.6f, 1.4f);
            audioSource.volume = Random.Range(0f, 0.15f);
            audioSource.Play();
        }
    }

}
