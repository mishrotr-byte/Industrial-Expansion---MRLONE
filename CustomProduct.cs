using StardewValley;

namespace IndustrialExpansionMRLONE
{
    public class CustomProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        public int ProductionDays { get; set; }
        public int Popularity { get; set; }

        public StardewValley.Object CreateObject()
        {
            return new StardewValley.Object(
                Vector2.Zero,
                388, // временно используем ID дерева как основу
                Name,
                true,
                true,
                false,
                false)
            {
                Price = Price
            };
        }
    }
}
