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

    public virtual void SetLevel(int newLevel)
    {
        Level = newLevel;
    }

    public virtual void LevelUp()
    {
        Level++;
    }
}

[MessagePackObject]
public class ShopHorizontalBarLevel : ShopItemLevel
{
    public ShopHorizontalBarLevel(int value) : base(value)
    {

    }

    public override void SetLevel(int newLevel)
    {
        base.SetLevel(newLevel);
        The.EventManager.EnvironmentChanged?.Invoke(Level);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        The.EventManager.EnvironmentChanged?.Invoke(Level);
    }
}
