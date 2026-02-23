using StardewModdingAPI;
using StardewValley;

namespace IndustrialExpansionMRLONE
{
    public class EconomyManager
    {
        private readonly IModHelper Helper;

        public int BrandPopularity { get; private set; } = 0;
        public int Reputation { get; private set; } = 0;

        public EconomyManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void ProcessDailyEconomy()
        {
            BrandPopularity += 1;
            Reputation += 1;
        }

        public void LoadData()
        {
            var data = Helper.Data.ReadSaveData<EconomySaveData>("economy-data");
            if (data != null)
            {
                BrandPopularity = data.BrandPopularity;
                Reputation = data.Reputation;
            }
        }

        public void SaveData()
        {
            Helper.Data.WriteSaveData("economy-data", new EconomySaveData
            {
                BrandPopularity = BrandPopularity,
                Reputation = Reputation
            });
        }
    }

    public class EconomySaveData
    {
        public int BrandPopularity { get; set; }
        public int Reputation { get; set; }
    }
}
using StardewModdingAPI;

namespace IndustrialExpansionMRLONE.Economy
{
    public class EconomyManager
    {
        private readonly IModHelper Helper;
        private int Revenue;
        private int BrandLevel = 1;

        public EconomyManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void AddRevenue(int amount)
        {
            Revenue += amount;
        }

        public void ProcessDaily()
        {
            if (Revenue > BrandLevel * 1000)
                BrandLevel++;
        }

        public void Load()
        {
            Revenue = Helper.Data.ReadSaveData<int>("revenue");
        }

        public void Save()
        {
            Helper.Data.WriteSaveData("revenue", Revenue);
        }
    }
}
