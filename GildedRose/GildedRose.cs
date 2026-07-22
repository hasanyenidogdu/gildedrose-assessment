using GildedRoseKata.Factories;
using GildedRoseKata.Models;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items) 
        {
            ItemUpdaterFactory.Create(item).Update(item);
        }
    }
}