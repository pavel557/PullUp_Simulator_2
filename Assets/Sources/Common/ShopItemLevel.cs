using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MessagePackObject]
public class ShopItemLevel
{
    [Key(0)] private int level;

    public ShopItemLevel() 
    {
        level = 0;
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }

    public void LevelUp()
    {
        level++;
    }

    public int GetLevel()
    {
        return level;
    }
}
