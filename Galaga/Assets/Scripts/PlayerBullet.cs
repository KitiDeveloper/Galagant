using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5;
    private float timer = 0;

    GameObject gameManagerObj;
    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
    }

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;

        if (timer <= 2)
        {
            rb.velocity = new Vector2(0, moveSpeed);
            return;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject DeathAudio = GameObject.Find("AlienDeathAudio");
            AudioSource audioSource = DeathAudio.GetComponent<AudioSource>();
            audioSource.Play();

            gameManager.AddScore();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
