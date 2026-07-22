using GildedRoseKata.Base;
using GildedRoseKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Updaters
{
    internal class SulfurasUpdater  : ItemUpdaterBase
    {
        protected override void UpdateQuality(Item item)
        {
            // Quality never changes for this item
        }

        protected override void UpdateSellIn(Item item)
        {
            // Never has to be sold
        }

        protected override void UpdateWhenExpired(Item item)
        {
            // Update not needed for this item
        }
    }
}
