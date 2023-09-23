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

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldDegradeQualityWithoutRemainingSellDaysAtTwoPerDay()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 6 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(4, items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(2, items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldIncreaseQualityOfAgedBrieWithRemainingSellDaysAtOnePerDay()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(1, items[0].Quality);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldNotIncreaseQualityOfAgedBrieWithoutRemainingSellDaysBeyondFifty()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldNotChangeQualityOrSaleDateOfSulfuras()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(1, items[0].SellIn);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldIncreaseQualityOfBackstagePassesByOneIf11DaysOrMoreRemaining()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 5 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(6, items[0].Quality);
    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldIncreaseQualityOfBackstagePassesBTwoIfBetween10DaysAnd6DaysRemaining()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        // 9 days remaining
        Assert.Equal(7, items[0].Quality);

        app.UpdateQuality();
        // 8 days remaining
        Assert.Equal(9, items[0].Quality);

        app.UpdateQuality();
        // 7 days remaining
        Assert.Equal(11, items[0].Quality);

        app.UpdateQuality();
        // 6 days remaining
        Assert.Equal(13, items[0].Quality);

        app.UpdateQuality();
        // 5 days remaining
        Assert.Equal(15, items[0].Quality);

    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldIncreaseQualityOfBackstagePassesByThreeIfBetween5DaysAnd1DayRemaining()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
        GildedRose app = new GildedRose(items);

        int oldQuality = items[0].Quality;
        app.UpdateQuality();
        // 4 days remaining
        Assert.Equal(oldQuality + 3, items[0].Quality);

        oldQuality = items[0].Quality;
        app.UpdateQuality();
        // 3 days remaining
        Assert.Equal(oldQuality + 3, items[0].Quality);

        oldQuality = items[0].Quality;
        app.UpdateQuality();
        // 2 days remaining
        Assert.Equal(oldQuality + 3, items[0].Quality);

        oldQuality = items[0].Quality;
        app.UpdateQuality();
        // 1 days remaining
        Assert.Equal(oldQuality + 3, items[0].Quality);

        oldQuality = items[0].Quality;
        app.UpdateQuality();
        // 0 days remaining
        Assert.Equal(oldQuality + 3, items[0].Quality);

    }

    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldDegradeQualityOfBackstagePassesToZeroWithZeroDaysRemaining()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }


    [Trait("Category", "AcceptanceTest")]
    [Fact]
    public void ShouldDegradeQualityOfConjuredItemWithRemainingSellDaysAtTwoPerDay()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Conjured Bread", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();
        Assert.Equal(18, items[0].Quality);
    }
}