using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using Xunit;

namespace GildedRoseTests.UpdaterTests
{
    public class AgedBrieUpdaterTests
    {
        private readonly AgedBrieUpdater _updater = new();

        [Fact]
        public void IncreasesInQuality()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.AgedBrie, sellIn: 2, quality: 0);

            Assert.Equal(1, item.SellIn);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void IncreasesTwiceAsFastAfterSellDate()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.AgedBrie, sellIn: 0, quality: 10);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void QualityNeverExceedsFifty()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.AgedBrie, sellIn: 2, quality: 50);

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void QualityNeverExceedsFiftyWhenExpired()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.AgedBrie, sellIn: 0, quality: 49);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }
    }
}
