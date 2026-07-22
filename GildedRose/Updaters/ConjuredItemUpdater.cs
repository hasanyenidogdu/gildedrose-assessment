using GildedRoseKata.Base;
using GildedRoseKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Updaters
{
    internal class ConjuredItemUpdater : ItemUpdaterBase
    {
        protected override void UpdateQuality(Item item)
        {
            DecreaseQuality(item, amount: 2);
        }

        protected override void UpdateWhenExpired(Item item)
        {
            DecreaseQuality(item, amount: 2);
        }
    }
}
