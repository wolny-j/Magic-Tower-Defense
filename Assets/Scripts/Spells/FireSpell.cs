using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    bool hit = false;
    GameObject firePoint;

    public float moveSpeed = 500f;
    Rigidbody2D rb;

    PlayerMovement target;
    Vector2 moveDirection;

    void Start()
    {
        firePoint = GameObject.Find("FirePoint");
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (firePoint.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.MoveTowards(transform.position, firePoint.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            PlayerPrefs.SetInt("IsCasted", 0);
            Destroy(gameObject);
            firePoint.SetActive(false);
            
        }

        if (collision.gameObject.tag == "Tower")
        {

            PlayerPrefs.SetInt("IsCasted", 0);
            Destroy(gameObject);
            firePoint.SetActive(false);
        }

        if (collision.gameObject.tag == "Enemy" && hit == false)
        {


            hit = true;
            PlayerPrefs.SetInt("IsCasted", 0);

            firePoint.SetActive(false);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyKnight" && hit == false)
        {


            hit = true;
            PlayerPrefs.SetInt("IsCasted", 0);

            firePoint.SetActive(false);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyTank" && hit == false)
        {


            hit = true;
            PlayerPrefs.SetInt("IsCasted", 0);

            firePoint.SetActive(false);
            Destroy(gameObject);
        }
    }
}
