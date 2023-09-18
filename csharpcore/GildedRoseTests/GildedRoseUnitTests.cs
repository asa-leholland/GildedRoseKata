using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseUnitTest
    {

        [Trait("Category", "UnitTest")]
        [Fact]
        public void UpdateQuality_AgedBrieItem_QualityIncreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(21, items[0].Quality);
        }

        [Trait("Category", "UnitTest")]
        [Fact]
        public void UpdateQuality_SulfurasItem_QualityStaysSame()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(80, items[0].Quality);
        }

        [Trait("Category", "UnitTest")]
        [Fact]
        public void UpdateQuality_BackstagePassesItem_QualityIncreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(21, items[0].Quality);
        }

    }
}
