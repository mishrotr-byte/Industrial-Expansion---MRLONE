using StardewValley;

namespace IndustrialExpansionMRLONE.Systems
{
    public class MarketingSystem
    {
        private readonly WorldState State;

        public MarketingSystem(WorldState state)
        {
            State = state;
        }

        public void StartCampaign(string type)
        {
            if (State.ActiveCampaign != null)
                return;

            if (type == "TV")
            {
                State.ActiveCampaign = new MarketingCampaignData
                {
                    Type = "TV",
                    RemainingDays = 5,
                    DemandBoost = 1.5f,
                    ReputationBoost = 1.2f,
                    Cost = 10000
                };
            }

            if (State.ActiveCampaign != null)
            {
                Game1.player.Money -= State.ActiveCampaign.Cost;

                Game1.addHUDMessage(new HUDMessage(
                    $"📢 Campaign Started: {State.ActiveCampaign.Type}", 2));
            }
        }

        public void DailyUpdate()
        {
            if (State.ActiveCampaign == null)
                return;

            State.ActiveCampaign.RemainingDays--;

            if (State.ActiveCampaign.RemainingDays <= 0)
            {
                Game1.addHUDMessage(new HUDMessage("📢 Campaign ended", 2));
                State.ActiveCampaign = null;
            }
        }
    }
}
