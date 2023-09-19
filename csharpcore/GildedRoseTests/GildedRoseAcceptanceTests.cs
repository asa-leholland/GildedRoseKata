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

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldNeverDegradeQualityBelowZero()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldDegradeSellInValueByOneEachDay()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
        GildedRose app = new GildedRose(items);

        for (var daysElapsed = 1; daysElapsed < 10; daysElapsed++)
        {
            app.UpdateQuality();
            Assert.Equal(10 - daysElapsed, items[0].SellIn);
        }
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldDegradeQualityWithRemainingSellDaysAtOnePerDay()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 20, Quality = 6 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(5, items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(4, items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(3, items[0].Quality);
    }
}