using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;

namespace IndustrialExpansionMRLONE
{
    public class FactoryManager
    {
        private readonly IModHelper Helper;

        private Dictionary<string, int> ProductionQueue = new();

        public FactoryManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void StartProduction(string itemId, int days)
        {
            ProductionQueue[itemId] = Game1.Date.TotalDays + days;
        }

        public void ProcessProduction()
        {
            List<string> finished = new();

            foreach (var entry in ProductionQueue)
            {
                if (Game1.Date.TotalDays >= entry.Value)
                {
                    Game1.player.addItemByMenuIfNecessaryElseHoldUp(ItemRegistry.Create(entry.Key));
                    finished.Add(entry.Key);
                }
            }

            foreach (var f in finished)
                ProductionQueue.Remove(f);
        }
    }
}
