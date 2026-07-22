using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using Xunit;

namespace GildedRoseTests.UpdaterTests
{
    public class StandardItemUpdaterTests
    {
        private readonly StandardItemUpdater _updater = new();

        [Fact]
        public void DegradesQualityAndSellInByOne()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.DexterityVest, sellIn: 10, quality: 20);

            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void DegradesTwiceAsFastAfterSellDate()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ElixirOfTheMongoose, sellIn: 0, quality: 10);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void QualityNeverGoesNegative()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ElixirOfTheMongoose, sellIn: 5, quality: 0);

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void QualityNeverGoesNegativeWhenExpired()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.ElixirOfTheMongoose, sellIn: 0, quality: 1);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}
