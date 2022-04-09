using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    GameObject player;
    GameObject towerObj;
    PlayerStats playerStats;
    public Text goldInfo;
    Tower tower;
    public GameObject fireSpell1;
    public GameObject fireSpell2;
    public GameObject fireSpell3;
    public GameObject natureSpell1;
    public GameObject natureSpell2;
    public GameObject natureSpell3;
    public GameObject frostSpell1;
    public GameObject frostSpell2;
    public GameObject frostSpell3;
    public GameObject littleFirend;
    void Start()
    {
        player = GameObject.Find("Player");
        towerObj = GameObject.Find("Tower");
        tower = towerObj.GetComponent<Tower>();
        playerStats = player.GetComponent<PlayerStats>();


    }

    // Update is called once per frame
    void Update()
    {
        goldInfo.text = playerStats.p1.GetGold().ToString();
    }

    public void BuySpell1()
    {


        if (playerStats.p1.GetGold() >= 800)
        {
            PlayerPrefs.SetInt("Unlock2", 1);
            playerStats.p1.SubstractGold(800);
            switch (playerStats.inventory.GetSize())
            {
                case 1:
                    frostSpell1.SetActive(true);
                    break;
                case 2:
                    frostSpell2.SetActive(true);
                    break;
                case 3:
                    frostSpell3.SetActive(true);
                    break;
            }
            playerStats.inventory.AddItem(new SpellType("Frost", 10));
        }


    }
    public void BuySpell2()
    {

        if (playerStats.p1.GetGold() >= 1200)
        {
            PlayerPrefs.SetInt("Unlock1", 1);
            playerStats.p1.SubstractGold(1200);
            switch (playerStats.inventory.GetSize())
            {
                case 1:
                    fireSpell1.SetActive(true);
                    break;
                case 2:
                    fireSpell2.SetActive(true);
                    break;
                case 3:
                    fireSpell3.SetActive(true);
                    break;
            }
            playerStats.inventory.AddItem(new SpellType("Fire", 15));
        }

    }
    public void BuySpell3()
    {

        if (playerStats.p1.GetGold() >= 1000)
        {

            playerStats.p1.SubstractGold(1000);
            PlayerPrefs.SetInt("Unlock3", 1);
            switch (playerStats.inventory.GetSize())
            {
                case 1:
                    natureSpell1.SetActive(true);
                    break;
                case 2:
                    natureSpell2.SetActive(true);
                    break;
                case 3:
                    natureSpell3.SetActive(true);
                    break;
            }
            playerStats.inventory.AddItem(new SpellType("Nature", 15));
        }


    }

    public void BuyLittleFirend()
    {
        if (playerStats.p1.GetGold() >= 1000)
        {
            littleFirend.SetActive(true);
            playerStats.p1.SubstractGold(1000);
        }
    }
    public void BuyManaPotion()
    {
        if (playerStats.p1.GetGold() >= 40)
        {
            playerStats.p1.AddManaPotion();
            playerStats.p1.SubstractGold(40);
        }
    }

    public void BuyHPPotion()
    {
        if (playerStats.p1.GetGold() >= 40)
        {
            playerStats.p1.AddHpPotion();
            playerStats.p1.SubstractGold(40);
        }
    }


    public void SellKey()
    {
        if (playerStats.p1.GetKeys() >= 1)
        {
            playerStats.p1.SubstractKeys();
            playerStats.p1.AddGold(50);
        }
    }

    public void HealTower()
    {
        if (PlayerPrefs.GetInt("Scroll5") == 0)
        {
            if (playerStats.p1.GetGold() >= 10 && tower.health <= 95)
            {
                tower.health = tower.health + 10;

                playerStats.p1.SubstractGold(10);
            }
        }
        else if (PlayerPrefs.GetInt("Scroll5") == 1)
            if (playerStats.p1.GetGold() >= 10 && tower.health <= 120)
            {
                tower.health = tower.health + 10;

                playerStats.p1.SubstractGold(10);
            }
    }

}


