using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string _name;
    float _health;
    float _mana;
    float _manaRegen;
    float _gold;
    float _exp;
    int _slillPoint;
    int _level;
    float _attack;
    float _defence;
    float _maxHp;
    float _maxMana;
    int _manaPotion;
    int _manaPotionPower;
    int _hpPotion;
    int _hpPotionPower;
    int _keys;
    int _books;

    public Player()             //Class containging powerup name and id
    {
        _name = "x";

        _health = 1;
        _mana = 1;
        _gold = 1;
        _exp = 1;

    }
    public Player(string name, float health, float maxHP, float mana, float manaRegen, float gold, float exp, int skillPoint,
        int level, float attack, float defence, int manaPotion, int manaPotionPower, int hpPotion, int hpPotionPower, int keys, int books)             //Class containging powerup name and id
    {
        _name = name;

        _health = health;
        _mana = mana;
        _gold = gold;
        _exp = exp;
        _slillPoint = skillPoint;
        _level = level;
        _attack = attack;
        _defence = defence;
        _maxHp = maxHP;
        _maxMana = mana;
        _manaRegen = manaRegen;
        _hpPotion = hpPotion;
        _manaPotion = manaPotion;
        _keys = keys;
        _books = books;
        _manaPotionPower = manaPotionPower;
        _hpPotionPower = hpPotionPower;

    }

    public float GetHealth()
    {
        return Mathf.RoundToInt(_health);

    }
    public float GetMaxHealth()
    {
        return Mathf.RoundToInt(_maxHp);
    }
    public void AddMaxHealth(float x)
    {
        _maxHp += x;
    }

    public void EditHealth(float x)
    {
        _health = x;
    }
    public void AddHealth(float x)
    {
        _health = _health + x;
    }
    public void SubstractHealth(float x)
    {
        _health = _health - x;
    }
    public float GetMana()
    {
        return _mana;
    }
    public float GetManaRegen()
    {
        return _manaRegen;
    }
    public void AddManaRegen(float x)
    {
        _manaRegen += x;
    }
    public float GetMaxMana()
    {
        return _maxMana;
    }
    public void AddMaxMana(float x)
    {
        _maxMana += x;
    }

    public void EditMana(float x)
    {
        _mana = x;
    }
    public void AddMana(float x)
    {
        _mana = _mana + x;
    }
    public void SubstractMana(float x)
    {
        _mana -= x;
    }
    public float GetGold()
    {
        return _gold;
    }

    public void EditGold(float x)
    {
        _gold = x;
    }
    public void AddGold(float x)
    {
        _gold = _gold + x;
    }
    public void SubstractGold(float x)
    {
        _gold = _gold - x;
    }
    public float GetExp()
    {
        return _exp;
    }

    public void EditExp(float x)
    {
        _exp = x;
    }
    public void AddExp(float x)
    {
        _exp = _exp + x;
    }
    public void SubstractExp(float x)
    {
        _exp = _exp - x;
    }

    public int GetSkillPoints()
    {
        return _slillPoint;
    }

    public void EditSkillPoints(int x)
    {
        _slillPoint = x;
    }
    public void AddSkillPoints(int x)
    {
        _slillPoint += x;
    }
    public void SubstractSkillPoints(int x)
    {
        _slillPoint -= x;
    }
    public float GetAttack()
    {
        return _attack;
    }

    public void EditAttack(int x)
    {
        _attack = x;
    }
    public void AddAttack(float x)
    {
        _attack = _attack + x;
    }
    public void SubstractAttack(int x)
    {
        _attack = _attack - x;
    }
    public float GetDefence()
    {
        return _defence;
    }
    public void EditDefence(int x)
    {
        _defence = x;
    }
    public void AddDefence(float x)
    {
        _defence = _defence + x;
    }
    public void SubstractDefence(int x)
    {
        _defence = _defence - x;
    }
    public float GetLevel()
    {
        return _level;
    }
    public void EditLevel(int x)
    {
        _level = x;
    }
    public void AddLevel(int x)
    {
        _level = _level + x;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetName(string x)
    {
        _name = x;
    }
    public int GetManaPotion()
    {
        return _manaPotion;
    }
    public void AddManaPotion()
    {
        _manaPotion++;
    }
    public void SubstractManaPotion()
    {
        _manaPotion--;
    }
    public int GetHPPotion()
    {
        return _hpPotion;
    }
    public void AddHpPotion()
    {
        _hpPotion++;
    }
    public void SubstractHPPotion()
    {
        _hpPotion--;
    }
    public int GetKeys()
    {
        return _keys;
    }
    public void AddKeys()
    {
        _keys++;
    }
    public void SubstractKeys()
    {
        _keys--;
    }

    public int GetBooks()
    {
        return _books;
    }
    public void AddBooks()
    {
        _books++;
    }
    public void SubstractBooks()
    {
        _books--;
    }

    public int GetManaPotionPower()
    {
        return _manaPotionPower;
    }

    public void AddManaPotionPower(int x)
    {
        _manaPotionPower = _manaPotionPower + x;
    }

    public int GetHPPotionPower()
    {
        return _hpPotionPower;
    }

    public void AddHPPotionPower(int x)
    {
        _hpPotionPower = _hpPotionPower + x;
    }

}
