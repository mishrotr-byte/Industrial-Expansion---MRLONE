using StardewModdingAPI;

namespace IndustrialExpansionMRLONE.Reputation
{
    public class ReputationManager
    {
        private readonly IModHelper Helper;
        private ReputationData Data = new();

        public ReputationManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void Load()
        {
            Data = Helper.Data.ReadSaveData<ReputationData>("reputation") ?? new();
        }

        public void Save()
        {
            Helper.Data.WriteSaveData("reputation", Data);
        }

        public void AddExperience(int amount)
        {
            Data.Experience += amount;
            Data.Influence += amount / 2;

            if (Data.Experience >= Data.Level * 500)
            {
                Data.Level++;
                Data.Experience = 0;
                Data.MarketShare += 2;
                Data.Trust += 5;
            }
        }

        public void Penalize(int amount)
        {
            Data.Trust -= amount;
            if (Data.Trust < 0)
                Data.Trust = 0;
        }

        public ReputationData Get() => Data;
    }
}
