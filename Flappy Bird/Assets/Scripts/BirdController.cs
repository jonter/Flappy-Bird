using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    float speed = 2.5f;
    float jumpSpeed = 10;
    float gravity = 3;

    bool isOn = false;
    bool isAlive = true;

    public event Action OnDeath;
    public event Action OnPlay;

    AudioSource audio;
    [SerializeField] AudioClip hitSFX;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isOn == false) StartGame();
            rb.velocity = new Vector2(speed, jumpSpeed);
            audio.Play();
        }
        RotateBird();
    }

    void RotateBird()
    {
        Vector3 dir = new Vector3(rb.velocity.x, rb.velocity.y / 2, 0);
        transform.right = dir;
    }

    void StartGame()
    {
        isOn = true;
        rb.gravityScale = gravity;
        if(OnPlay != null) OnPlay();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAlive == false) return;
        if(collision.tag == "Obstacle")
        {
            Death();
        }
    }

    void Death()
    {
        isAlive = false;
        rb.velocity = new Vector2(-speed/2, jumpSpeed);
        if (OnDeath != null) OnDeath();
        audio.PlayOneShot(hitSFX);
    }
}
