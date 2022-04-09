using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBat : MonoBehaviour
{
    float speed = 8f;
    float health;
    float maxHealth;
    public Slider healthBar;
    public Image hp;
    PlayerStats playerStats;
    GameObject player;
    bool fired = false;
    float firedCounter;
    int fireRepeat;
    public SpriteRenderer sprite;
    Vector2 distance;
    Vector2 temp;

    void Start()
    {
        player = GameObject.Find("Player");
        maxHealth = 130 + (PlayerPrefs.GetInt("Wave") * 3);
        playerStats = player.GetComponent<PlayerStats>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = health;
        healthBar.maxValue = maxHealth;
        distance = (player.transform.position - transform.position);

        if (distance.sqrMagnitude < 20)
        {
            speed = 6f;
        }
        else
        {
            speed = 8f;
        }

        float step = speed * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);


        firedCounter += Time.deltaTime;
        if (fired)
        {
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
        if (health < 0)
        {
            if (PlayerPrefs.GetInt("Scroll2") == 0)
            {
                playerStats.p1.AddExp(15);
            }
            else if (PlayerPrefs.GetInt("Scroll2") == 1)
            {
                playerStats.p1.AddExp(18);
            }
            playerStats.p1.AddGold(20);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats.p1.SubstractHealth(50 - 50 * (playerStats.p1.GetDefence() / 100));
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Spell")
        {

            health -= playerStats.p1.GetAttack() * 6;
            healthBar.value = health;
            Debug.Log(health);
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

        }
        if (collision.gameObject.tag == "PixieSpell")
        {
            health -= (playerStats.p1.GetAttack() * 6) / 4;
            healthBar.value = health;

        }
    }
}
