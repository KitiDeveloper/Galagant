using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    private GameObject playerShip;
    private PlayerMovement playerStats;

    bool shouldDie = false;

    public GameObject hitExplosion;

    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    void Start()
    {
        playerShip = GameObject.Find("Player");
        playerStats = playerShip.GetComponent<PlayerMovement>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        isReady = true;
    }

    private void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime;

            transform.position = position;



            float minX = -5.5f;
            float maxX = 5.5f;
            float minY = -5.5f;
            float maxY = 6.5f;

            if ((transform.position.x < minX || (transform.position.x > maxX) ||
                (transform.position.y < minY) || (transform.position.y > maxY)))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (playerStats.numberOfLifes > 1)
            {
                Destroy(gameObject);
                playerStats.numberOfLifes = playerStats.numberOfLifes - 1;

                hitExplosion.transform.position = transform.position;
                GameObject.Instantiate(hitExplosion);

                GameObject hitAudio = GameObject.Find("PlayerHitAudio");
                AudioSource audioSource = hitAudio.GetComponent<AudioSource>();
                audioSource.Play();
            }
            else if (shouldDie)
            {
                Destroy(gameObject);
            }
            else
            {
                shouldDie = true;
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject obj in allObjects)
                {
                    Destroy(obj);
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
