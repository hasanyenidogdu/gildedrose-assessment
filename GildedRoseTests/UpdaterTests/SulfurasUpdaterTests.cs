using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRoseTests.UpdaterTests
{
    public class SulfurasUpdaterTests
    {
        private readonly SulfurasUpdater _updater = new();

        [Fact]
        public void NeverChangesSellInOrQuality()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.Sulfuras, sellIn: 0, quality: 80);

            Assert.Equal(0, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void NeverChangesWhenSellInIsNegative()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.Sulfuras, sellIn: -1, quality: 80);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void NeverChangesWhenSellInIsPositive()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.Sulfuras, sellIn: 5, quality: 80);

            Assert.Equal(5, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
