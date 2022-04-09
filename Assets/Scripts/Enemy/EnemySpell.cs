using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    float moveSpeed = 15f;
    Rigidbody2D rb;

    GameObject player;
    GameObject tower;


    Vector2 moveDirection;
    Vector2 distance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        moveDirection = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * moveSpeed;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Tree")
        {
            Destroy(gameObject);
        }

    }
}
