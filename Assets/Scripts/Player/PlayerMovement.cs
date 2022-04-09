using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public GameObject firePoint;
    float runSpeed = 55f;
    public GameObject tower;


    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D player;
    float verticalMove;
    float speed = 8f;
    bool isLadder;
    bool isClimbing;
    int jumpCounter = 0;
    bool isFalling = false;

    public bool isGrounded;

    public Animator animator;
    public GameObject commandConsole;
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), tower.GetComponent<Collider2D>());
        PlayerPrefs.SetInt("2jump", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandConsole.activeSelf == false)
        {
            if (PlayerPrefs.GetInt("Scroll1") == 1)
            {
                runSpeed = 65;
            }


            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            verticalMove = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (isLadder && Mathf.Abs(verticalMove) > 0)
            {
                isClimbing = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }



        /*if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/

    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            Debug.Log(player.velocity.y);
            if (player.velocity.y == 0)
            {
                player.transform.position = player.transform.position + new Vector3(0, -1 * (speed / 2) * Time.deltaTime);
            }
            player.gravityScale = 0;
            player.velocity = new Vector2(player.velocity.x, verticalMove * 12f);
        }
        else
        {
            player.gravityScale = 4f;
        }
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "GroundMask")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }



    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}
