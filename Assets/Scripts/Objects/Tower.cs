using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public Slider healthBar;
    public GameObject restartPanel;
    bool upgrade = false;
   
    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("Scroll5") == 1 && upgrade == false)
        {
            maxHealth = 125f;
            healthBar.maxValue = maxHealth;
            health = maxHealth;
            upgrade = true;
        }
        
        healthBar.value = health;
        
        if (health <= 0)
        {
            
            restartPanel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySpell")
        {

            health -= 5;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "EnemyTank")
        {

            health -= 50;
            Destroy(collision.gameObject);

        }
    }
}
