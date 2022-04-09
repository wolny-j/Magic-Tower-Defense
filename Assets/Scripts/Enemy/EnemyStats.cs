using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{

    GameObject _enemy;
    float _health;
    float _gold;
    float _exp;
    int _attack;
    int _defence;


    public EnemyStats()             //Class containging powerup name and id
    {


        _health = 1;

        _gold = 1;
        _exp = 1;

    }
    public EnemyStats(float health)             //Class containging powerup name and id
    {

        _health = health;

    }

    public float GetHealth()
    {
        return _health;
    }

    public void EditHealth(float x)
    {
        _health = x;
    }

    /*public float GetGold()
    {
        return _gold;
    }

    void EditGold(float x)
    {
        _gold = x;
    }
    public float GetExp()
    {
        return _exp;
    }

    void EditExp(float x)
    {
        _exp = x;
    }
    public float GetAttack()
    {
        return _attack;
    }

    void EditAttack(int x)
    {
        _attack = x;
    }
    public float GetDefence()
    {
        return _defence;
    }

    void EditDefence(int x)
    {
        _defence = x;
    }*/

}
