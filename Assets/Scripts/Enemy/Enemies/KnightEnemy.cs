using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 5f;
    float health = 150;
    float maxHealth;
    public Slider healthBar;
    public Image hp;
    PlayerStats playerStats;
    CastingSpells controller2D;
    GameObject player;
    public Animation swordAttack;
    bool animateAttack = false;
    float counter = 0f;
    bool move = true;
    bool animateAttackTower = false;
    GameObject tower;
    Tower towerStats;
    Tree treeHealth;
    bool fired = false;
    float firedCounter = 0;
    int fireRepeat = 0;
    public SpriteRenderer sprite;
    bool frosted = false;
    float frostCounter = 0;
    bool animateAttackTree = false;

    void Start()
    {
        maxHealth = 160 + (PlayerPrefs.GetInt("Wave") * 2);
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
            moveSpeed = 4f;
        }
        if (animateAttack)
        {
            counter += Time.deltaTime;
            if (counter > 2)
            {
                swordAttack.Play();
                counter = 0;
                playerStats.p1.SubstractHealth(10 - 10 * (playerStats.p1.GetDefence() / 100));
            }
        }
        if (animateAttackTower)
        {
            counter += Time.deltaTime;
            if (counter > 2)
            {
                towerStats.health = towerStats.health - 10;
                swordAttack.Play();
                counter = 0;

            }
        }
        if (animateAttackTree)
        {
            counter += Time.deltaTime;
            if (counter > 2)
            {
                swordAttack.Play();
                treeHealth.health = treeHealth.health - 10;
                counter = 0;

            }
        }
        if (move)
        {
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (health <= 0)
        {
            playerStats.p1.AddGold(13);
            if (PlayerPrefs.GetInt("Scroll2") == 0)
            {
                playerStats.p1.AddExp(10);
            }
            else if (PlayerPrefs.GetInt("Scroll2") == 1)
            {
                playerStats.p1.AddExp(12);
            }
            AddKey();
            AddBook();
            PlayerPrefs.SetFloat("Gold", PlayerPrefs.GetFloat("Gold") + 10);
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
            sprite.color = new Color32(96, 94, 94, 255);
        }

        if (frosted)
        {
            frostCounter += Time.deltaTime;
            sprite.color = new Color32(8, 59, 188, 255);
            if (frostCounter > 4 + PlayerPrefs.GetInt("Spell3"))
            {
                moveSpeed = moveSpeed * 3;
                frostCounter = 0;
                frosted = false;
            }
        }
        else if (fired != true && frosted != true)
        {
            sprite.color = new Color32(96, 94, 94, 255);
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
            sprite.color = new Color32(255, 103, 11, 255);
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

        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("InTower") == 0)
            {
                move = false;
                animateAttack = true;
                swordAttack.Play();
                playerStats.p1.SubstractHealth(10 - 10 * (playerStats.p1.GetDefence() / 100));
            }
        }

        if (collision.gameObject.tag == "Tower")
        {

            animateAttackTower = true;
            swordAttack.Play();

        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
            animateAttack = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.tag == "EnemyTank")
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
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("tree");

            swordAttack.Play();
            treeHealth = collision.gameObject.GetComponent<Tree>();
            animateAttackTree = true;
        }

    }
    public void AddKey()
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
