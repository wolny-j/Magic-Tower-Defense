using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<SpellType> itemList;

    public Inventory()
    {
        itemList = new List<SpellType>();

        AddItem(new SpellType("Plasma", 5));
    }

    public void AddItem(SpellType item)
    {
        itemList.Add(item);
    }
    public int GetSize()
    {
        return itemList.Count;
    }
    public SpellType GetItem(int x)
    {
        return itemList[x];
    }

    public void Clear()
    {
        itemList.Clear();
    }
}
