using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using Xunit;

namespace GildedRoseTests.UpdaterTests
{
    public class ConjuredItemUpdaterTests
    {
        private readonly ConjuredItemUpdater _updater = new();

        [Fact]
        public void DegradesTwiceAsFastAsNormal()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ConjuredManaCake, sellIn: 3, quality: 6);

            Assert.Equal(2, item.SellIn);
            Assert.Equal(4, item.Quality);
        }

        [Fact]
        public void DegradesByFourAfterSellDate()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ConjuredManaCake, sellIn: 0, quality: 6);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void QualityNeverGoesNegative()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ConjuredManaCake, sellIn: 3, quality: 1);

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void QualityNeverGoesNegativeWhenExpired()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ConjuredManaCake, sellIn: 0, quality: 3);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}
