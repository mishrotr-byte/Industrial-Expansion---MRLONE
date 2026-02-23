using StardewModdingAPI;
using StardewValley;
using System;

namespace IndustrialExpansionMRLONE.Corporate
{
    public class CorporateWarSystem
    {
        private readonly IModHelper Helper;

        public CorporateWarSystem(IModHelper helper)
        {
            Helper = helper;
        }

        public void DailyUpdate()
        {
            if (!Context.IsMainPlayer)
                return;

            if (Game1.random.NextDouble() > 0.95)
            {
                LaunchCorporateAttack();
            }
        }

        private void LaunchCorporateAttack()
        {
            int roll = Game1.random.Next(3);

            if (roll == 0)
            {
                // Демпинг
                ModEntry.Instance.Competitor.Get().MarketShare += 3f;
            }
            else if (roll == 1)
            {
                // Судебный иск
                Game1.player.Money -= 5000;
                ModEntry.Instance.Reputation.Penalize(10);
            }
            else
            {
                // Рейдерская атака
                ModEntry.Instance.Reputation.Penalize(20);
            }
        }
    }
}
