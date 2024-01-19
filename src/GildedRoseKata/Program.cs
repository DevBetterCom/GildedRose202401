namespace GildedRoseKata;

public class Program
{
    public IList<Item> Items;
    static void Main2(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            Items = new List<Item>
                                      {
                                          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                          new Item
                                              {
                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                  SellIn = 15,
                                                  Quality = 20
                                              },
                                          new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                      }

        };

        app.UpdateQuality();

        System.Console.ReadKey();

    }

    private void UpdateNormalItem(ItemProxy item)
    {
        item.DecrementQuality();
        item.DecrementSellIn();
        if (item.SellIn < 0)
        {
            item.DecrementQuality();

        }
    }

    public void UpdateItemQuality(ItemProxy item)
    {
        if (item.Name == "Sulfuras, Hand of Ragnaros") return;

        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            UpdateNormalItem(item);
            return;
        }

            item.IncrementQuality();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    item.IncrementQuality();
                }

                if (item.SellIn < 6)
                {
                    item.IncrementQuality();
                }
            }

        item.DecrementSellIn();

        if (item.SellIn < 0)
        {
            if (item.Name == "Aged Brie")
            {
                item.IncrementQuality();
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.ResetQualityToZero();
            }

        }
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateItemQuality(new ItemProxy(Items[i]));
        }
    }

}

public class ItemProxy
{
    private readonly Item _item;

    public ItemProxy(Item item)
    {
        _item = item;
    }
    public string Name => _item.Name;

    public int SellIn
    {
        get
        {
            return _item.SellIn;
        }
        private set
        {
            _item.SellIn = value;
        }
    }

    public int Quality
    {
        get
        {
            return _item.Quality;
        }
        private set
        {
            _item.Quality = value;
        }
    }

    public void IncrementQuality()
    {
        if (_item.Quality < 50)
        {
            Quality = Quality + 1;
        }
    }

    public void DecrementQuality()
    {
        if (_item.Quality > 0)
        {
            Quality = Quality - 1;
        }
    }

    public void DecrementSellIn()
    {
        SellIn--;
    }

    public void ResetQualityToZero()
    {
        Quality = 0;
    }

}

public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}
