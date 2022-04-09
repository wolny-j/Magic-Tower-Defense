using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public float health;
    public float mana;
    public float manaRegen;
    public float gold;
    public float exp;
    public int slillPoint;
    public float level;
    public float attack;
    public float defence;
    public float maxHp;
    public float maxMana;
    public int manaPotion;
    public int manaPotionPower;
    public int hpPotion;
    public int hpPotionPower;
    public int keys;
    public int books;
    public float towerMaxHealth;
    public float towerHealth;
    public int fireSpell;
    public int frostSpell;
    public int natureSpell;
    public int scroll1;
    public int scroll2;
    public int scroll3;
    public int scroll4;
    public int scroll5;
    public int plasmaUpgrade;
    public int fireUpgrade;
    public int frostUpgrade;
    public int natureUpgrade;
    public int wave;
    public float posX;
    public float posY;
    public int s1Counter;
    public int s2Counter;
    public int s3Counter;
    public int s4Counter;
    public int manaPotionCounter;
    public int hpPotionCounter;
    public string date;
    public int deaths;

    public bool isLittleFriend = false;


    public PlayerData(PlayerStats player, Tower tower, CastingSpells castingSpells)
    {
        name = player.p1.GetName();
        health = player.p1.GetHealth();
        mana = player.p1.GetMana();
        manaRegen = player.p1.GetManaRegen();
        gold = player.p1.GetGold();
        exp = player.p1.GetExp();
        slillPoint = player.p1.GetSkillPoints();
        level = player.p1.GetLevel();
        attack = player.p1.GetAttack();
        defence = player.p1.GetDefence();
        maxHp = player.p1.GetMaxHealth();
        maxMana = player.p1.GetMaxMana();
        manaPotion = player.p1.GetManaPotion();
        hpPotion = player.p1.GetHPPotion();
        manaPotionPower = player.p1.GetManaPotionPower();
        hpPotionPower = player.p1.GetHPPotionPower();
        keys = player.p1.GetKeys();
        books = player.p1.GetBooks();
        towerMaxHealth = tower.maxHealth;
        towerHealth = tower.health;
        fireSpell = PlayerPrefs.GetInt("Unlock1");
        frostSpell = PlayerPrefs.GetInt("Unlock2");
        natureSpell = PlayerPrefs.GetInt("Unlock3");
        scroll1 = PlayerPrefs.GetInt("Scroll1");
        scroll2 = PlayerPrefs.GetInt("Scroll2");
        scroll3 = PlayerPrefs.GetInt("Scroll3");
        scroll4 = PlayerPrefs.GetInt("Scroll4");
        scroll5 = PlayerPrefs.GetInt("Scroll5");
        plasmaUpgrade = PlayerPrefs.GetInt("Spell1");
        fireUpgrade = PlayerPrefs.GetInt("Spell2");
        frostUpgrade = PlayerPrefs.GetInt("Spell3");
        natureUpgrade = PlayerPrefs.GetInt("Spell4");

        wave = PlayerPrefs.GetInt("Wave");

        s1Counter = castingSpells.s1Counter;
        s2Counter = castingSpells.s2Counter;
        s3Counter = castingSpells.s3Counter;
        s4Counter = castingSpells.s4Counter;

        posX = player.transform.position.x;
        posY = player.transform.position.y;
        date = System.DateTime.Now.ToString();
        //date = date.Split(' ')[0];
        hpPotionCounter = player.hpPotionCounter;
        manaPotionCounter = player.manaPotionCounter;
        deaths = player.playerStats.deathsCounter;
        GameObject littleFriend = null;
        littleFriend = GameObject.Find("PixieTarget");
        GameObject littleFriendChild = littleFriend.transform.Find("Pixie").gameObject;
        if (littleFriendChild.activeSelf == true)
        {
            isLittleFriend = true;
        }
        else
        {
            isLittleFriend = false;
        }
    }
}
