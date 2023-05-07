using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int numberOfLifes = 4;

    public GameObject playerExplosion;

    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    public float moveSpeed = 10.0f;
    public InputAction playerControls;

    [Header("Limit movement")]
    public float minX = 1f;
    public float maxX = -1f;

    public GameObject gameOver;
    public GameObject play;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        //clamps the x position of the player
        float xposition = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector2(xposition, transform.position.y);

        Physics2D.IgnoreLayerCollision(7, 8);
    }

    private void FixedUpdate()
    {
        //Reads the player input and moves the player with that input value
        moveVector = playerControls.ReadValue<Vector2>();
        rb.velocity = new Vector2(moveVector.x * moveSpeed, 0);
    }

    private void OnDestroy()
    {
        GameObject canvas = GameObject.Find("Lifes");
        Destroy(canvas);

        GameObject deathAudio = GameObject.Find("PlayerDeathAudio");
        AudioSource audioSource = deathAudio.GetComponent<AudioSource>();
        audioSource.Play();

        playerExplosion.transform.position = transform.position;
        GameObject.Instantiate(playerExplosion);

        gameOver.SetActive(true);

        play.SetActive(true);
    }
}
