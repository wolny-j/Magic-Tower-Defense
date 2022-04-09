using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    float health;
    float maxHealth = 3500;
    public Slider healthBar;
    public Image hp;
    PlayerStats playerStats;
    public GameObject player;
    bool fired = false;
    float firedCounter;
    int fireRepeat;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = health;
        healthBar.maxValue = maxHealth;
        if (fired)
        {


            firedCounter += Time.deltaTime;

            if (firedCounter >= 1 && fireRepeat == 0)
            {
                health -= maxHealth * 0.05f;
                fireRepeat++;
            }
            else if (firedCounter >= 2 && fireRepeat == 1)
            {
                health -= maxHealth * 0.05f;
                fireRepeat++;
            }
            else if (firedCounter >= 3 && fireRepeat == 2)
            {
                health -= maxHealth * 0.05f;
                firedCounter = 0;
                fireRepeat = 0;
                fired = false;
            }
        }
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Spell")
        {

            health -= playerStats.p1.GetAttack() * 6;
            healthBar.value = health;
        }
        if (collision.gameObject.tag == "FireSpell")
        {

            health -= playerStats.p1.GetAttack() * 20;
            healthBar.value = health;
            fired = true;

        }
        if (collision.gameObject.tag == "FrostSpell")
        {
            health -= playerStats.p1.GetAttack() * 8;
            healthBar.value = health;
        }

    }
}
