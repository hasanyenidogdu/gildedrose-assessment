using GildedRoseKata.Updaters;
using GildedRoseTests.TestHelpers;
using Xunit;

namespace GildedRoseTests.UpdaterTests
{
    public class BackstagePassUpdaterTests
    {
        private readonly BackstagePassUpdater _updater = new();

        [Fact]
        public void IncreasesByOneWhenMoreThanTenDays()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.BackstagePasses, sellIn: 15, quality: 20);

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void IncreasesByTwoWhenTenDaysOrLess()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.BackstagePasses, sellIn: 10, quality: 20);

            Assert.Equal(9, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void IncreasesByThreeWhenFiveDaysOrLess()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.BackstagePasses, sellIn: 5, quality: 20);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void DropsToZeroAfterConcert()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.BackstagePasses, sellIn: 0, quality: 20);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void QualityNeverExceedsFifty()
        {
            var item = ItemTestHelper.Update(_updater, ItemNames.BackstagePasses, sellIn: 5, quality: 49);

            Assert.Equal(50, item.Quality);
        }
    }
}
