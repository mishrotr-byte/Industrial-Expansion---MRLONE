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
