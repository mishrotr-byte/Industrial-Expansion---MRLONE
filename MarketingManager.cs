using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;

namespace IndustrialExpansionMRLONE.Marketing
{
    public class MarketingManager
    {
        private readonly IModHelper Helper;
        private MarketingCampaign? ActiveCampaign;

        public MarketingManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void StartCampaign(string type)
        {
            if (ActiveCampaign != null)
                return;

            if (type == "TV")
            {
                ActiveCampaign = new MarketingCampaign
                {
                    Name = "TV Campaign",
                    RemainingDays = 5,
                    DemandBoost = 1.5f,
                    Cost = 10000
                };
            }

            if (ActiveCampaign != null)
                Game1.player.Money -= ActiveCampaign.Cost;
        }

        public void DailyUpdate()
        {
            if (ActiveCampaign == null)
                return;

            ActiveCampaign.RemainingDays--;

            if (ActiveCampaign.RemainingDays <= 0)
                ActiveCampaign = null;
        }

        public float GetBoost() => ActiveCampaign?.DemandBoost ?? 1f;

        public void Save() => Helper.Data.WriteSaveData("marketing", ActiveCampaign);
        public void Load() => ActiveCampaign = Helper.Data.ReadSaveData<MarketingCampaign>("marketing");
    }
}
