using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public float health = 40;
    public SpriteRenderer sprite;
    Enemy enemy;
    GameObject enemyObject;
    bool enemyTouched = false;

    void Start()
    {
        health = health + +(PlayerPrefs.GetInt("Spell4") * 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (enemyTouched == true)
            {
                enemy.treeTouched = false;
                enemyTouched = false;
            }
            Destroy(gameObject);
        }
        if (health <= 20)
        {

            sprite.color = new Color(175, 100, 8);
        }
        if (PlayerPrefs.GetInt("WavePart") == 7)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySpell")
        {
            health = health - 10;

        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemyObject = collision.gameObject;
            enemy = enemyObject.GetComponent<Enemy>();
            enemyTouched = true;

        }
        if (collision.gameObject.tag == "EnemyTank")
        {
            Destroy(gameObject);

        }



    }


}
