using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MessagePackObject]
public class Shop
{
    [Key(0)] public ShopHorizontalBarLevel LevelHorizontalBar { get; set; }
    [Key(1)] public ShopItemLevel LevelBed { get; set; }
    [Key(2)] public ShopItemLevel LevelFood { get; set; }
    [Key(3)] public ShopItemLevel LevelCloth { get; set; }
    [Key(4)] public ShopItemLevel LevelMusic { get; set; }

    public Shop()
    {
        LevelHorizontalBar = new ShopHorizontalBarLevel(0);
        LevelBed = new ShopItemLevel(0);
        LevelFood = new ShopItemLevel(0);
        LevelCloth = new ShopItemLevel(0);
        LevelMusic = new ShopItemLevel(0);
    }
}
