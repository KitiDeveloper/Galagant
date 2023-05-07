using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private bool hasShot;
    public float Timer = 0;
    private float upgradeTimer = 0;
    public bool hasUpgradeFireRate = false;
    private bool needsToReset = false;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SpawnBullet();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            SpawnBullet();
        }
    }

    private void FixedUpdate()
    {
        if (hasUpgradeFireRate)
        {
            Timer = Timer + Time.deltaTime;
            upgradeTimer = upgradeTimer + Time.deltaTime;
            if (needsToReset)
            {
                upgradeTimer = 0;
                Timer = 0;
                needsToReset = false;
            }
            else if (Timer > 6)
            {
                hasUpgradeFireRate = false;
            }
            else if (upgradeTimer > .2f)
            {
                upgradeTimer = 0;
                hasShot = false;
            }
        }
        else if (Timer >= 0.5f)
        {
            hasShot = false;
            Timer = 0;
        }
        else if(hasShot)
        {
            Timer = Timer + Time.deltaTime;
        }
    }

    public void SpawnBullet()
    {
        if (!hasShot)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            GameObject shootAudio = GameObject.Find("PlayerShootAudio");
            AudioSource audioSource = shootAudio.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.75f, 1.25f);
            audioSource.volume = Random.Range(0.1f, 0.5f);
            audioSource.Play();
        }
        hasShot = true;
    }
}
