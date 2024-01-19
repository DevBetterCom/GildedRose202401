using Xunit;

namespace GildedRose.Tests
{
    public class ProgramUpdateQuality
    {
        [Fact]
        public void DoesNotChangeSulfurasQuality()
        {
            var program = new Program
            {
                                  Items = new[]
                                  {
                                                  new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
                                              }
                              };    
            program.UpdateQuality();

            Assert.Equal(80, program.Items[0].Quality);
        }
    }
}