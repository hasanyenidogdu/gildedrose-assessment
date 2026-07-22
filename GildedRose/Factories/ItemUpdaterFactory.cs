using GildedRoseKata.Base;
using GildedRoseKata.Models;
using GildedRoseKata.Updaters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseKata.Factories
{
    internal class ItemUpdaterFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string ConjuredManaCake = "Conjured Mana Cake";

        public static ItemUpdaterBase Create(Item item)
        {
            if (item.Name == AgedBrie)
            {
                return new AgedBrieUpdater();
            }

            if (item.Name == BackstagePasses)
            {
                return new BackstagePassUpdater();
            }

            if (item.Name == Sulfuras)
            {
                return new SulfurasUpdater();
            }

            if (item.Name == ConjuredManaCake)
            {
                return new ConjuredItemUpdater();
            }

            return new StandardItemUpdater();
        }
    }
}
