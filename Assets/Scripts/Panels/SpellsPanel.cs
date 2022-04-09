using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsPanel : MonoBehaviour
{
    public Text booksInfo;
    public Text spell1Level;
    public Text spell2Level;
    public Text spell3Level;
    public Text spell4Level;
    public Text hpPotionPower;
    public Text manaPotionPower;
    public Text costInfo1;
    public Text costInfo2;
    public Text costInfo3;
    public Text costInfo4;
    public Text goldInfo;
    PlayerStats playerStats;
    GameObject player;
    int cost1 = 1;
    int cost2 = 1;
    int cost3 = 1;
    int cost4 = 1;
    void Start()
    {

        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        manaPotionPower.text = playerStats.p1.GetManaPotionPower().ToString();
        hpPotionPower.text = playerStats.p1.GetHPPotionPower().ToString();


    }

    // Update is called once per frame
    void Update()
    {
        goldInfo.text = playerStats.p1.GetGold().ToString();
        booksInfo.text = playerStats.p1.GetBooks().ToString();
        spell1Level.text = PlayerPrefs.GetInt("Spell1").ToString();
        spell2Level.text = PlayerPrefs.GetInt("Spell2").ToString();
        spell3Level.text = PlayerPrefs.GetInt("Spell3").ToString();
        spell4Level.text = PlayerPrefs.GetInt("Spell4").ToString();
        hpPotionPower.text = playerStats.p1.GetHPPotionPower().ToString();
        manaPotionPower.text = playerStats.p1.GetManaPotionPower().ToString();
    }

    public void UpgradeSpell1()
    {
        if (playerStats.p1.GetBooks() >= cost1 && PlayerPrefs.GetInt("Spell1") <= 3 && playerStats.p1.GetGold() >= 100)
        {
            PlayerPrefs.SetInt("Spell1", PlayerPrefs.GetInt("Spell1") + 1);
            playerStats.p1.SubstractGold(100);
            spell1Level.text = PlayerPrefs.GetInt("Spell1").ToString();
            if (PlayerPrefs.GetInt("Spell1") <= 2)
            {
                costInfo1.text = "Upgrade - 1 book";
                playerStats.p1.SubstractBooks();
                if (PlayerPrefs.GetInt("Spell1") == 2)
                {
                    costInfo1.text = "Upgrade - 2 books";
                }
            }
            else if (PlayerPrefs.GetInt("Spell1") > 2)
            {

                cost1 = 2;
                playerStats.p1.SubstractBooks();
                playerStats.p1.SubstractBooks();
            }
            if (PlayerPrefs.GetInt("Spell1") == 4)
            {
                spell1Level.text = "4 - MAX";
            }
        }

    }

    public void UpgradeSpell2()
    {
        if (playerStats.p1.GetBooks() >= cost2 && PlayerPrefs.GetInt("Unlock1") == 1 && playerStats.p1.GetGold() >= 100)
        {
            PlayerPrefs.SetInt("Spell2", PlayerPrefs.GetInt("Spell2") + 1);
            playerStats.p1.SubstractGold(100);
            if (PlayerPrefs.GetInt("Spell2") <= 5)
            {
                costInfo2.text = "Upgrade - 1 book";
                playerStats.p1.SubstractBooks();
                if (PlayerPrefs.GetInt("Spell2") == 5)
                {
                    costInfo2.text = "Upgrade - 2 books";
                    cost2 = 2;
                }
            }
            else if (PlayerPrefs.GetInt("Spell2") > 5)
            {

                cost2 = 2;
                playerStats.p1.SubstractBooks();
                playerStats.p1.SubstractBooks();
            }
            spell2Level.text = PlayerPrefs.GetInt("Spell2").ToString();
        }

    }
    public void UpgradeSpell3()
    {
        if (playerStats.p1.GetBooks() >= cost3 && PlayerPrefs.GetInt("Unlock2") == 1 && playerStats.p1.GetGold() >= 100)
        {
            PlayerPrefs.SetInt("Spell3", PlayerPrefs.GetInt("Spell3") + 1);
            playerStats.p1.SubstractGold(100);
            if (PlayerPrefs.GetInt("Spell3") <= 5)
            {
                costInfo3.text = "Upgrade - 1 book";
                playerStats.p1.SubstractBooks();
                if (PlayerPrefs.GetInt("Spell3") == 5)
                {
                    costInfo3.text = "Upgrade - 2 books";
                    cost3 = 2;
                }
            }
            else if (PlayerPrefs.GetInt("Spell3") > 5)
            {

                cost3 = 2;
                playerStats.p1.SubstractBooks();
                playerStats.p1.SubstractBooks();
            }
            spell3Level.text = PlayerPrefs.GetInt("Spell3").ToString();
        }

    }
    public void UpgradeSpell4()
    {
        if (playerStats.p1.GetBooks() >= cost4 && PlayerPrefs.GetInt("Unlock3") == 1 && playerStats.p1.GetGold() >= 100)
        {
            PlayerPrefs.SetInt("Spell4", PlayerPrefs.GetInt("Spell4") + 1);
            playerStats.p1.SubstractGold(100);
            if (PlayerPrefs.GetInt("Spell4") <= 5)
            {
                costInfo4.text = "Upgrade - 1 book";
                playerStats.p1.SubstractBooks();
                if (PlayerPrefs.GetInt("Spell4") == 5)
                {
                    costInfo4.text = "Upgrade - 2 books";
                    cost4 = 2;
                }

            }
            else if (PlayerPrefs.GetInt("Spell4") > 5)
            {

                cost4 = 2;
                playerStats.p1.SubstractBooks();
                playerStats.p1.SubstractBooks();
            }
            spell4Level.text = PlayerPrefs.GetInt("Spell4").ToString();
        }

    }

    public void BuyHPPotionPower()
    {
        if (playerStats.p1.GetGold() >= 100 && playerStats.p1.GetBooks() >= 1)
        {
            playerStats.p1.AddHPPotionPower(20);
            playerStats.p1.SubstractBooks();
            playerStats.p1.SubstractGold(100);
            hpPotionPower.text = playerStats.p1.GetHPPotionPower().ToString();
        }
    }

    public void BuyManaPotionPower()
    {
        if (playerStats.p1.GetGold() >= 100 && playerStats.p1.GetBooks() >= 1)
        {
            playerStats.p1.AddManaPotionPower(7);
            playerStats.p1.SubstractBooks();
            playerStats.p1.SubstractGold(100);
            manaPotionPower.text = playerStats.p1.GetManaPotionPower().ToString();
        }
    }

}
