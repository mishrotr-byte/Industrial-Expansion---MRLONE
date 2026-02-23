using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialExpansionMRLONE.Factory
{
    public class ContractManager
    {
        private readonly IModHelper Helper;
        private List<Contract> Contracts = new();

        public ContractManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void GenerateDailyContracts(List<CustomProduct> products)
        {
            if (!Context.IsMainPlayer)
                return;

            Contracts.Clear();

            if (!products.Any())
                return;

            var rand = new Random(Game1.Date.TotalDays);

            foreach (var p in products.Take(3))
            {
                Contracts.Add(new Contract
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = p.Id,
                    RequiredAmount = rand.Next(5, 20),
                    Reward = p.Price * rand.Next(10, 25),
                    DeadlineDay = Game1.Date.TotalDays + rand.Next(3, 7)
                });
            }

            Save();
        }

        public void CheckDeadlines()
        {
            foreach (var c in Contracts)
            {
                if (!c.Completed && Game1.Date.TotalDays > c.DeadlineDay)
                {
                    c.Failed = true;
                    ModEntry.Instance.Economy.AddRevenue(-c.Reward / 2);
                }
            }
        }

        public void CompleteContract(Contract contract)
        {
            contract.Completed = true;
            ModEntry.Instance.Economy.AddRevenue(contract.Reward);
            Save();
        }

        public List<Contract> GetContracts() => Contracts;

        public void Save()
        {
            Helper.Data.WriteSaveData("contracts", Contracts);
        }

        public void Load()
        {
            Contracts = Helper.Data.ReadSaveData<List<Contract>>("contracts") ?? new();
        }
    }
}
