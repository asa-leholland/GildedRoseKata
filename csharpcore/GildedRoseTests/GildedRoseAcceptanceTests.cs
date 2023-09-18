using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseAcceptanceTest
{
    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void SystemRuns()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }
}