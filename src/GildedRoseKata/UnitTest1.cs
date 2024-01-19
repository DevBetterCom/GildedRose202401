namespace GildedRoseKata;

public class ProgramUpdateQuality
{
    private Program _program = new Program() { Items = new List<Item>() };
    [Fact]
    public void DoesNotAlterSulfurasQuality()
    {
        var item = GetSulfuras();

        _program.UpdateItemQuality(item);

        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void DoesNotAlterSulfurasSellIn()
    {
        var item = GetSulfuras();

        _program.UpdateItemQuality(item);

        Assert.Equal(0, item.SellIn);
    }

    private ItemProxy GetSulfuras()
    {
        return new ItemProxy(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
    }
}