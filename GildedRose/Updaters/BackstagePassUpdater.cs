using GildedRoseKata.Base;
using GildedRoseKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Updaters
{
    internal class BackstagePassUpdater : ItemUpdaterBase
    {
        protected override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);

            if(item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if(item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        protected override void UpdateWhenExpired(Item item)
        {
            item.Quality = MinQuality;
        }
    }
}
