using GildedRoseKata.Base;
using GildedRoseKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Updaters
{
    internal class AgedBrieUpdater : ItemUpdaterBase
    {
        protected override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);
        }

        protected override void UpdateWhenExpired(Item item)
        {
            IncreaseQuality(item);
        }
    }
}
