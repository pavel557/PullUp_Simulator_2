using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MessagePackObject]
public class ShopItemLevel
{
    [Key(0)] public int Level;

    public ShopItemLevel(int value) 
    {
        Level = value;
    }

    public void SetLevel(int newLevel)
    {
        Level = newLevel;
    }

    public void LevelUp()
    {
        Level++;
    }
}
