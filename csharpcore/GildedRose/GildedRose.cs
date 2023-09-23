using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
            if (!IsLegendary(item))
            {
                var UpdatedItem = UpdateQualityAndSellInForItem(item);
                _items[i] = UpdatedItem;
            }
        }
    }

    private static bool IsLegendary(Item item)
    {
        return item.Name == "Sulfuras, Hand of Ragnaros";
    }

    public static void UpdateQualityBy(Item item, int amount)
    {
        const int maxQuality = 50;
        const int minQuality = 0;
        if (item.Quality + amount > maxQuality)
        {
            item.Quality = maxQuality;
        }
        else if (item.Quality + amount < minQuality)
        {
            item.Quality = minQuality;
        }
        else
        {
            item.Quality += amount;
        }
    }

    private Item UpdateQualityAndSellInForItem(Item item)
    {
        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            UpdateQualityBy(item, +1);

            if (item.SellIn < 11)
            {
                UpdateQualityBy(item, +1);
            }

            if (item.SellIn < 6)
            {
                UpdateQualityBy(item, +1);
            }
        }
        else if (item.Name.ToLower().Contains("conjured"))
        {
            UpdateQualityBy(item, -2);
        }
        else if (item.Name == "Aged Brie")
        {
            UpdateQualityBy(item, +1);
        }
        else
        {
            UpdateQualityBy(item, -1);
        }

        item.SellIn--;
        HandleSellInEqualsZero(item);
        return item;
    }

    private static void HandleSellInEqualsZero(Item item)
    {
        if (item.SellIn < 0)
        {
            if (item.Name == "Aged Brie")
            {
                UpdateQualityBy(item, +1);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            else
            {
                UpdateQualityBy(item, -1);
            }
        }
    }
}