using GildedRoseKata.Factories;
using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRoseTests.FactoryTests
{
    public class ItemUpdaterFactoryTests
    {
        [Fact]
        public void Create_ReturnsAgedBrieUpdater_ForAgedBrie()
        {
            var item = ItemTestHelper.CreateItem(ItemNames.AgedBrie, sellIn: 2, quality: 0);
            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<AgedBrieUpdater>(updater);
        }

        [Fact]
        public void Create_ReturnsBackstagePassUpdater_ForBackstagePasses()
        {
            var item = ItemTestHelper.CreateItem(ItemNames.BackstagePasses, sellIn: 15, quality: 20);

            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<BackstagePassUpdater>(updater);
        }

        [Fact]
        public void Create_ReturnsSulfurasUpdater_ForSulfuras()
        {
            var item = ItemTestHelper.CreateItem(ItemNames.Sulfuras, sellIn: 0, quality: 80);

            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<SulfurasUpdater>(updater);
        }

        [Fact]
        public void Create_ReturnsConjuredItemUpdater_ForConjuredManaCake()
        {
            var item = ItemTestHelper.CreateItem(ItemNames.ConjuredManaCake, sellIn: 3, quality: 6);

            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<ConjuredItemUpdater>(updater);
        }

        [Fact]
        public void Create_ReturnsStandardItemUpdater_ForOrdinaryItems()
        {
            var item = ItemTestHelper.CreateItem(ItemNames.DexterityVest, sellIn: 10, quality: 20);

            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<StandardItemUpdater>(updater);
        }

        [Fact]
        public void Create_ReturnsStandardItemUpdater_ForUnknownItems()
        {
            var item = ItemTestHelper.CreateItem("Unknown Item", sellIn: 5, quality: 10);

            var updater = ItemUpdaterFactory.Create(item);

            Assert.IsType<StandardItemUpdater>(updater);
        }
    }
}
