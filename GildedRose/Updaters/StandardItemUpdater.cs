using GildedRoseKata.Base;
using GildedRoseKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Updaters
{
    internal class StandardItemUpdater : ItemUpdaterBase
    {
        protected override void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
        }

        protected override void UpdateWhenExpired(Item item)
        {
            DecreaseQuality(item);
        }
    }
}
