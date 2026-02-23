using StardewModdingAPI;
using StardewValley;
using System;

namespace IndustrialExpansionMRLONE.AI
{
    public class CompetitorAI
    {
        private readonly IModHelper Helper;
        private CompetitorData Data = new();

        public CompetitorAI(IModHelper helper)
        {
            Helper = helper;
        }

        public void DailyUpdate()
        {
            Random r = new Random(Game1.Date.TotalDays + 99);

            int investment = r.Next(1000, 5000);
            Data.Capital += investment;

            if (r.NextDouble() > 0.7)
            {
                Data.MarketShare += 1f;
            }

            if (r.NextDouble() > 0.9)
            {
                Data.Aggressiveness++;
            }

            Data.MarketShare = Math.Clamp(Data.MarketShare, 5f, 60f);
        }

        public float GetCompetitionModifier()
        {
            return 1f - (Data.MarketShare / 200f);
        }

        public CompetitorData Get() => Data;

        public void Save()
        {
            Helper.Data.WriteSaveData("competitor", Data);
        }

        public void Load()
        {
            Data = Helper.Data.ReadSaveData<CompetitorData>("competitor") ?? new();
        }
    }
}
