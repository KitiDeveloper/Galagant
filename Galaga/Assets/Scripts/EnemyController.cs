using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed;

    GameObject player;

    private Rigidbody2D rb;

    private GameObject playerShip;
    private PlayerMovement playerStats;

    bool shouldDie = false;

    public GameObject enemyExplosion;

    public GameObject hitExplosion;

    void Start()
    {
        playerShip = GameObject.Find("Player");
        playerStats = playerShip.GetComponent<PlayerMovement>();

        speed = 2f;
        this.player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        GameObject spawnAudio = GameObject.Find("AlienSpawnAudio");
        AudioSource audioSource = spawnAudio.GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.6f, 1.4f);
        audioSource.volume = Random.Range(0f, 0.15f);
        audioSource.Play();
    }

    private void Update()
    {
        float xposition = Mathf.Clamp(transform.position.x, -5, 5);
        transform.position = new Vector2(xposition, transform.position.y);

        Physics2D.IgnoreLayerCollision(9, 10);
    }

    void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        MoveToPlayer(direction.normalized);

        //Vector2 position = transform.position;
        //position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        //transform.position = position;

        if(transform.position.y < -5.5 || transform.position.y > 6.5)
        {
            Destroy(gameObject);
        }

        void MoveToPlayer(Vector2 value)
        {
            value = new Vector2(Random.Range(value.x, Random.Range(-1f, 1f)), -0.8f);
            rb.MovePosition((Vector2)transform.position + (value * (speed) * Time.deltaTime));
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

    private void OnDestroy()
    {
        enemyExplosion.transform.position = transform.position;
        GameObject.Instantiate(enemyExplosion);
    }
}
