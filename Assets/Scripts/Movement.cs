﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float speed;
    public float jumpForce;
    bool isJumping = false;
    public Transform jumpingChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    Animator anim;
    GameObject playerFire;
    Light2D TheLight;
    CircleCollider2D playerCircleRadius;

    private float boostTimer;
    private bool isBoosted;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        playerFire = GameObject.FindWithTag("Fire");
        TheLight = playerFire.GetComponent<Light2D>();
        playerCircleRadius = playerFire.GetComponent<CircleCollider2D>();
        boostTimer = 0;
        isBoosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfJumping();
        if (isBoosted)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 20)
            {
                speed = 1f;
                boostTimer = 0;
                isBoosted = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            TheLight.pointLightOuterRadius += 1.5f;
            playerCircleRadius.radius += 1.5f;

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Item2")
        {
            isBoosted = true;
            speed = 1.5f;
            Destroy(collision.gameObject);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (Input.GetKey/*Down*/(KeyCode.D))
        {
            anim.Play("Lost_Walk_Right");
            sprite.flipX = false;
            // FindObjectOfType<AudioManager>().Play("Walking");

        }
        if (Input.GetKey/*Down*/(KeyCode.A))
        {
            anim.Play("Lost_Walk_Right");/*Left*/
            sprite.flipX = true;
            // FindObjectOfType<AudioManager>().Play("Walking");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.Play("Lost_Idle");
            // FindObjectOfType<AudioManager>().Pause("Walking");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.Play("Lost_Idle");/*_left*/
            //  FindObjectOfType<AudioManager>().Pause("Walking");
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.Play("Lost_Jump");
        }
    }

    void CheckIfJumping()
    {
        Collider2D collider = Physics2D.OverlapCircle(jumpingChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }
}
