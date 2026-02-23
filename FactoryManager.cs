using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialExpansionMRLONE
{
    public class FactoryManager
    {
        private readonly IModHelper Helper;

        private FactorySaveData Data = new();

        public FactoryManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void Load()
        {
            Data = Helper.Data.ReadSaveData<FactorySaveData>("factory-data") ?? new FactorySaveData();
        }

        public void Save()
        {
            Helper.Data.WriteSaveData("factory-data", Data);
        }

        public void AddProduct(CustomProduct product)
        {
            Data.Products.Add(product);
            Save();
        }

        public void StartProduction(string productId, int quantity)
        {
            if (!Context.IsMainPlayer)
                return;

            var product = Data.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return;

            Data.ActiveTasks.Add(new ProductionTask
            {
                ProductId = productId,
                Quantity = quantity,
                FinishDay = Game1.Date.TotalDays + product.ProductionDays
            });

            Save();
        }

        public void ProcessProduction()
        {
            if (!Context.IsMainPlayer)
                return;

            var finished = Data.ActiveTasks
                .Where(t => Game1.Date.TotalDays >= t.FinishDay)
                .ToList();

            foreach (var task in finished)
            {
                var product = Data.Products.First(p => p.Id == task.ProductId);

                for (int i = 0; i < task.Quantity; i++)
                {
                    Game1.player.addItemByMenuIfNecessaryElseHoldUp(product.CreateObject());
                }

                product.Popularity += task.Quantity;
                Data.ActiveTasks.Remove(task);
            }

            Save();
        }

        public List<CustomProduct> GetProducts() => Data.Products;
        public List<ProductionTask> GetTasks() => Data.ActiveTasks;
    }
}
using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialExpansionMRLONE.Factory
{
    public class FactoryManager
    {
        private readonly IModHelper Helper;
        private FactorySaveData Data = new();

        public FactoryManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void Load()
        {
            Data = Helper.Data.ReadSaveData<FactorySaveData>("factory-data") ?? new();
        }

        public void Save()
        {
            Helper.Data.WriteSaveData("factory-data", Data);
        }

        public void CreateProduct(string name, int price, int days)
        {
            Data.Products.Add(new CustomProduct
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = name,
                Price = price,
                ProductionDays = days
            });
        }

        public void StartProduction(string productId, int quantity)
        {
            if (!Context.IsMainPlayer)
                return;

            var product = Data.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return;

            Data.Tasks.Add(new ProductionTask
            {
                ProductId = productId,
                Quantity = quantity,
                FinishDay = Game1.Date.TotalDays + product.ProductionDays
            });
        }

        public void ProcessProduction()
        {
            if (!Context.IsMainPlayer)
                return;

            var done = Data.Tasks
                .Where(t => Game1.Date.TotalDays >= t.FinishDay)
                .ToList();

            foreach (var task in done)
            {
                var product = Data.Products.First(p => p.Id == task.ProductId);

                for (int i = 0; i < task.Quantity; i++)
                {
                    Game1.player.addItemByMenuIfNecessaryElseHoldUp(
                        new StardewValley.Object(388, 1)
                        {
                            Name = product.Name,
                            Price = product.Price
                        });
                }

                Data.Tasks.Remove(task);
                ModEntry.Instance.Economy.AddRevenue(product.Price * task.Quantity);
            }
        }

        public List<CustomProduct> GetProducts() => Data.Products;
        public List<ProductionTask> GetTasks() => Data.Tasks;
    }
}
