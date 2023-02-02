using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    /* Pause til 13:10
     *
     *  Refactoring
     *   - top-down vs bottom up
     *   - hovedteknikker
     *      - innføre variabel
     *      - trekke ut funksjon/metode (+generalisere!)
     *      - innføre klasse
     *      - if
     *          - snu if-setning + return eller break
     *          - slå sammen
     *   - gilded rose
     *   - enkelt bilspill
     *
     */
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQualityOneItem(Items[i]);
            }
        }

        private static void UpdateQualityOneItem(Item item)
        {
            var isAgedBrie = item.Name == "Aged Brie";
            var isBackstagePass = item.Name == "Backstage passes to a TAFKAL80ETC concert";
            if (!isAgedBrie && !isBackstagePass)
            {
                UpdateItemDegradeQuality(item);
            }
            else
            {
                UpdateItemUpgradeQuality(item);
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (!isAgedBrie)
                {
                    if (!isBackstagePass)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private static void UpdateItemUpgradeQuality(Item item)
        {
            if (item.Quality >= 50) return;
            item.Quality++;

            if (item.Quality >= 50 && item.SellIn >= 11
            && item.Name != "Backstage passes to a TAFKAL80ETC concert") return;

            var upgradeAmount = item.SellIn < 6 ? 2 : 1;
            item.Quality += upgradeAmount;
        }

        private static void UpdateItemDegradeQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
    }
}
