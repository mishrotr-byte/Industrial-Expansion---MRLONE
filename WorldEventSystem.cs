using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;

namespace IndustrialExpansionMRLONE.World
{
    public class WorldEventSystem
    {
        private readonly IModHelper Helper;
        private WorldEvent? ActiveEvent;

        public WorldEventSystem(IModHelper helper)
        {
            Helper = helper;
        }

        public void DailyUpdate()
        {
            if (!Context.IsMainPlayer)
                return;

            if (ActiveEvent == null && Game1.random.NextDouble() > 0.92)
            {
                TriggerRandomEvent();
            }

            if (ActiveEvent != null)
            {
                ActiveEvent.RemainingDays--;

                if (ActiveEvent.RemainingDays <= 0)
                    ActiveEvent = null;
            }
        }

        private void TriggerRandomEvent()
        {
            int roll = Game1.random.Next(3);

            if (roll == 0)
            {
                ActiveEvent = new WorldEvent
                {
                    Name = "Economic Crisis",
                    RemainingDays = 5,
                    GlobalDemandModifier = 0.6f
                };
            }
            else if (roll == 1)
            {
                ActiveEvent = new WorldEvent
                {
                    Name = "Inflation",
                    RemainingDays = 4,
                    GlobalDemandModifier = 1.2f
                };
            }
            else
            {
                ActiveEvent = new WorldEvent
                {
                    Name = "Tax Reform",
                    RemainingDays = 6,
                    TaxModifier = 1.3f
                };
            }
        }

        public float GetDemandModifier()
        {
            return ActiveEvent?.GlobalDemandModifier ?? 1f;
        }

        public float GetTaxModifier()
        {
            return ActiveEvent?.TaxModifier ?? 1f;
        }

        public WorldEvent? GetEvent() => ActiveEvent;

        public void Save() => Helper.Data.WriteSaveData("world-event", ActiveEvent);
        public void Load() => ActiveEvent = Helper.Data.ReadSaveData<WorldEvent>("world-event");
    }
}
