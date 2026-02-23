using System.Collections.Generic;

namespace IndustrialExpansionMRLONE
{
    public class FactorySaveData
    {
        public List<CustomProduct> Products { get; set; } = new();
        public List<ProductionTask> ActiveTasks { get; set; } = new();
        public int BrandLevel { get; set; } = 1;
    }
}
