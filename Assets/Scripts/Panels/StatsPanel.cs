using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    PlayerStats playerStats;
    GameObject player;
    GameObject towerObj;
    GameObject shopObj;
    Shop shop;

    Tower tower;
    public Text maxHp;
    public Text maxMana;
    public Text gold;
    public Text attack;
    public Text defence;
    public Text level;
    public Text skillpoints;
    public Text manaRegen;
    public Text scroll;
    public Button upgradeMaxHp;
    public Button upgradeMaxMana;
    public Button upgradeAttack;
    public Button upgradeDefence;
    void Start()
    {
        player = GameObject.Find("Player");
        towerObj = GameObject.Find("Tower");
        shopObj = GameObject.Find("ShopPanel");
        playerStats = player.GetComponent<PlayerStats>();
        tower = towerObj.GetComponent<Tower>();

    }

    // Update is called once per frame
    void Update()
    {

        maxHp.text = playerStats.p1.GetMaxHealth().ToString();
        maxMana.text = playerStats.p1.GetMaxMana().ToString();
        gold.text = playerStats.p1.GetGold().ToString();
        attack.text = playerStats.p1.GetAttack().ToString();
        defence.text = playerStats.p1.GetDefence().ToString();
        level.text = playerStats.p1.GetLevel().ToString();
        skillpoints.text = playerStats.p1.GetSkillPoints().ToString();
        manaRegen.text = (playerStats.p1.GetManaRegen() * 10).ToString();

        if (PlayerPrefs.GetInt("Scroll1") == 1)
        {
            scroll.text = "Scroll of speed";
        }
        else if (PlayerPrefs.GetInt("Scroll2") == 1)
        {
            scroll.text = "Scroll of intelligence";
        }
        else if (PlayerPrefs.GetInt("Scroll3") == 1)
        {
            scroll.text = "Scroll of mana";
        }
        else if (PlayerPrefs.GetInt("Scroll4") == 1)
        {
            scroll.text = "Scroll of slowness";
        }
        else if (PlayerPrefs.GetInt("Scroll5") == 1)
        {
            scroll.text = "Scroll of toughness";
        }

    }

    public void UpgradeMaxHP()
    {
        if (playerStats.p1.GetSkillPoints() >= 1)
        {
            playerStats.p1.AddMaxHealth(5);
            playerStats.p1.SubstractSkillPoints(1);
        }
    }

    public void UpgradeMaxMana()
    {
        if (playerStats.p1.GetSkillPoints() >= 1)
        {
            playerStats.p1.AddMaxMana(3);
            playerStats.p1.SubstractSkillPoints(1);
        }
    }

    public void UpgradeAttack()
    {
        if (playerStats.p1.GetSkillPoints() >= 1)
        {
            playerStats.p1.AddAttack(0.3f);
            playerStats.p1.SubstractSkillPoints(1);
        }
    }
    public void UpgradeDefence()
    {
        if (playerStats.p1.GetSkillPoints() >= 1)
        {
            playerStats.p1.AddDefence(2f);
            playerStats.p1.SubstractSkillPoints(1);
        }
    }
    public void UpgradeManaRegen()
    {
        if (playerStats.p1.GetSkillPoints() >= 1)
        {
            playerStats.p1.AddManaRegen(0.02f);
            playerStats.p1.SubstractSkillPoints(1);
        }
    }




}
