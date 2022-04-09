using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellType
{
    string _name;
    int _damage;

    public SpellType(string name, int damage)
    {
        _name = name;
        _damage = damage;
    }

    public string GetName()
    {
        return _name;
    }
}
