using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseTests.TestHelpers;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void UpdateQuality_UpdatesAllSampleInventoryItems()
    {
        IList<Item> items = new List<Item>
        {
            ItemTestHelper.CreateItem(ItemNames.DexterityVest, sellIn: 10, quality: 20),
            ItemTestHelper.CreateItem(ItemNames.AgedBrie, sellIn: 2, quality: 0),
            ItemTestHelper.CreateItem(ItemNames.ElixirOfTheMongoose, sellIn: 5, quality: 7),
            ItemTestHelper.CreateItem(ItemNames.Sulfuras, sellIn: 0, quality: 80),
            ItemTestHelper.CreateItem(ItemNames.Sulfuras, sellIn: -1, quality: 80),
            ItemTestHelper.CreateItem(ItemNames.BackstagePasses, sellIn: 15, quality: 20),
            ItemTestHelper.CreateItem(ItemNames.BackstagePasses, sellIn: 10, quality: 49),
            ItemTestHelper.CreateItem(ItemNames.BackstagePasses, sellIn: 5, quality: 49),
            ItemTestHelper.CreateItem(ItemNames.ConjuredManaCake, sellIn: 3, quality: 6)
        };

        new GildedRose(items).UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);

        Assert.Equal(1, items[1].SellIn);
        Assert.Equal(1, items[1].Quality);

        Assert.Equal(4, items[2].SellIn);
        Assert.Equal(6, items[2].Quality);

        Assert.Equal(0, items[3].SellIn);
        Assert.Equal(80, items[3].Quality);

        Assert.Equal(-1, items[4].SellIn);
        Assert.Equal(80, items[4].Quality);

        Assert.Equal(14, items[5].SellIn);
        Assert.Equal(21, items[5].Quality);

        Assert.Equal(9, items[6].SellIn);
        Assert.Equal(50, items[6].Quality);

        Assert.Equal(4, items[7].SellIn);
        Assert.Equal(50, items[7].Quality);

        Assert.Equal(2, items[8].SellIn);
        Assert.Equal(4, items[8].Quality);
    }
}