using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLaser : MonoBehaviour
{
    private GameObject playerShip;

    public GameObject batteryBullet;

    Vector2 _direction;

    void Start()
    {
        playerShip = GameObject.Find("Player");

        _direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(11, 8);
        Physics2D.IgnoreLayerCollision(11, 9);
        Physics2D.IgnoreLayerCollision(11, 10);

        Vector2 position = transform.position;

        position += _direction * 4f * Time.deltaTime;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject bullet = (GameObject)Instantiate(batteryBullet);

            bullet.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
