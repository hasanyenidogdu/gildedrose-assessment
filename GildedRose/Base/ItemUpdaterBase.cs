using GildedRoseKata.Models;
using System;

namespace GildedRoseKata.Base
{
    internal abstract class ItemUpdaterBase
    {
        protected const int MinQuality = 0;
        protected const int MaxQuality = 50;

        public void Update(Item item)
        {
            UpdateQuality(item);
            UpdateSellIn(item);

            if (item.SellIn < 0)
            {
                UpdateWhenExpired(item);
            }
        }

        protected abstract void UpdateQuality(Item item);
        protected virtual void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        protected abstract void UpdateWhenExpired(Item item);

        protected static void IncreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Min(MaxQuality, item.Quality + amount);
        }

        protected static void DecreaseQuality(Item item, int amount = 1) 
        {
            item.Quality = Math.Max(MinQuality, item.Quality - amount);
        }
    }
}
