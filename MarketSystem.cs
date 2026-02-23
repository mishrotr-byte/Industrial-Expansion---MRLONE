using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialExpansionMRLONE.Economy
{
    public class MarketSystem
    {
        private readonly IModHelper Helper;
        private List<MarketProductData> Market = new();

        public MarketSystem(IModHelper helper)
        {
            Helper = helper;
        }

        public void Initialize(List<string> productIds)
        {
            foreach (var id in productIds)
            {
                if (!Market.Any(m => m.ProductId == id))
                {
                    Market.Add(new MarketProductData
                    {
                        ProductId = id,
                        Demand = 1f,
                        Supply = 1f
                    });
                }
            }
        }

        public void DailyUpdate()
        {
            Random r = new Random(Game1.Date.TotalDays);

            foreach (var product in Market)
            {
                product.Demand += (float)(r.NextDouble() - 0.5) * 0.2f;
                product.Demand = Math.Clamp(product.Demand, 0.5f, 2.0f);

                product.Supply += (float)(r.NextDouble() - 0.5) * 0.1f;
                product.Supply = Math.Clamp(product.Supply, 0.5f, 2.0f);

                product.IsTrending = r.NextDouble() > 0.85;
            }
        }

        public float GetPriceMultiplier(string productId)
        {
            var p = Market.FirstOrDefault(m => m.ProductId == productId);
            if (p == null) return 1f;

            float trendBonus = p.IsTrending ? 1.3f : 1f;

            return (p.Demand / p.Supply) * trendBonus;
        }

        public List<MarketProductData> GetMarket() => Market;

        public void Save()
        {
            Helper.Data.WriteSaveData("market", Market);
        }

        public void Load()
        {
            Market = Helper.Data.ReadSaveData<List<MarketProductData>>("market") ?? new();
        }
    }
}
