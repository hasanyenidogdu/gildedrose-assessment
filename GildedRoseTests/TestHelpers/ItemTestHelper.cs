using GildedRoseKata.Base;
using GildedRoseKata.Models;

namespace GildedRoseTests.TestHelpers
{
    internal static class ItemTestHelper
    {
        public static Item CreateItem(string name, int sellIn, int quality) =>
            new() { Name = name, SellIn = sellIn, Quality = quality };

        public static Item Update(ItemUpdaterBase updater, string name, int sellIn, int quality)
        {
            var item = CreateItem(name, sellIn, quality);
            updater.Update(item);
            return item;
        }
    }
}