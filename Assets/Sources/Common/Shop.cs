using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MessagePackObject]
public class Shop
{
    [Key(0)] public ShopItemLevel LevelHorizontalBar { get; set; }
    [Key(1)] public ShopItemLevel LevelBed { get; set; }
    [Key(2)] public ShopItemLevel LevelFood { get; set; }
    [Key(3)] public ShopItemLevel LevelCloth { get; set; }
    [Key(4)] public ShopItemLevel LevelMusic { get; set; }

    public Shop()
    {
        LevelHorizontalBar = new ShopItemLevel();
        LevelBed = new ShopItemLevel();
        LevelFood = new ShopItemLevel();
        LevelCloth = new ShopItemLevel();
        LevelMusic = new ShopItemLevel();
    }
}
