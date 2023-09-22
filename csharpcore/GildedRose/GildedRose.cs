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
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }
            var UpdatedItem = UpdateQualityAndSellInForItem(item);
            _items[i] = UpdatedItem;
        }
    }

    private Item UpdateQualityAndSellInForItem(Item item)
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality > 0)
            {
                item.Quality --;
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality ++;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality ++;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality ++;
                        }
                    }
                }
            }
        }

        item.SellIn --;

        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        item.Quality --;
                    }
                }
                else
                {
                    item.Quality = 0;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality ++;
                }
            }
        }
        return item;
    }
}