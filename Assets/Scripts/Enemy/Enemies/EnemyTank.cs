using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTank : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 2f;
    float health = 800;
    float maxHealth;
    public Slider healthBar;
    public Image hp;
    PlayerStats playerStats;
    GameObject player;
    CastingSpells controller2D;


    bool move = true;

    GameObject tower;
    Tower towerStats;
    bool fired = false;
    float firedCounter = 0;
    int fireRepeat = 0;
    public SpriteRenderer sprite;
    bool frosted = false;
    float frostCounter = 0;

    void Start()
    {

        maxHealth = 800 + (PlayerPrefs.GetInt("Wave") * 3);
        rb = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>());
        player = GameObject.Find("Player");
        tower = GameObject.Find("Tower");
        playerStats = player.GetComponent<PlayerStats>();
        controller2D = player.GetComponent<CastingSpells>();
        towerStats = tower.GetComponent<Tower>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Scroll4") == 1)
        {
            moveSpeed = 1.5f;
        }
        rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);

        if (health <= 0)
        {
            playerStats.p1.AddGold(40);
            if (PlayerPrefs.GetInt("Scroll2") == 0)
            {
                playerStats.p1.AddExp(20);
            }
            else if (PlayerPrefs.GetInt("Scroll2") == 1)
            {
                playerStats.p1.AddExp(25);
            }
            AddKey();
            AddBook();
            PlayerPrefs.SetFloat("Gold", PlayerPrefs.GetFloat("Gold") + 40);
            Destroy(gameObject);
        }

        if (health < (maxHealth * 0.3))
        {
            hp.color = new Color32(255, 0, 48, 255);
        }

        if (fired)
        {
            firedCounter += Time.deltaTime;
            sprite.color = new Color32(255, 103, 11, 255);
            if (firedCounter >= 1 && fireRepeat == 0)
            {
                health -= maxHealth * (0.05f + (float)(PlayerPrefs.GetInt("Spell2") / 100f));

                fireRepeat++;
            }
            else if (firedCounter >= 2 && fireRepeat == 1)
            {
                health -= maxHealth * (0.05f + (float)(PlayerPrefs.GetInt("Spell2") / 100f));

                fireRepeat++;
            }
            else if (firedCounter >= 3 && fireRepeat == 2)
            {
                health -= maxHealth * (0.05f + (float)(PlayerPrefs.GetInt("Spell2") / 100f));

                firedCounter = 0;
                fireRepeat = 0;
                fired = false;
            }
        }
        else if (fired != true && frosted != true)
        {
            sprite.color = new Color32(168, 17, 52, 255);
        }

        if (frosted)
        {
            frostCounter += Time.deltaTime;
            sprite.color = new Color32(8, 59, 188, 255);
            if (frostCounter > 4)
            {
                moveSpeed = moveSpeed * 3;
                frostCounter = 0;
                frosted = false;
            }
        }
        else if (fired != true && frosted != true)
        {
            sprite.color = new Color32(168, 17, 52, 255);
        }

        healthBar.value = health;
        healthBar.maxValue = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jump")
        {

            rb.AddForce(Vector2.up * 3600f);
        }

        if (collision.gameObject.tag == "Spell")
        {
            if (PlayerPrefs.GetInt("Spell1") >= 1)
            {
                if (controller2D.facingRight == true)
                {
                    rb.AddForce(new Vector2((PlayerPrefs.GetInt("Spell1") * 4000), 0f));
                }
            }
            health -= playerStats.p1.GetAttack() * 6;
            healthBar.value = health;
        }

        if (collision.gameObject.tag == "FireSpell")
        {

            health -= playerStats.p1.GetAttack() * 8;
            healthBar.value = health;
            fired = true;
        }
        if (collision.gameObject.tag == "FrostSpell")
        {
            health -= playerStats.p1.GetAttack() * 8;
            healthBar.value = health;
            moveSpeed = moveSpeed / 3;
            frosted = true;
        }
        if (collision.gameObject.tag == "PixieSpell")
        {
            health -= (playerStats.p1.GetAttack() * 6) / 4;
            healthBar.value = health;

        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.collider.tag == "Ladder")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.collider.tag == "Wall")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }

    void AddKey()
    {
        if (Random.Range(1, 1000) <= 15 && playerStats.p1.GetKeys() < 3)
        {
            playerStats.p1.AddKeys();
        }
    }
    void AddBook()
    {
        if (Random.Range(1, 1000) <= 40)
        {
            playerStats.p1.AddBooks();
            PlayerPrefs.SetInt("AddBook", 1);
        }
    }
}
