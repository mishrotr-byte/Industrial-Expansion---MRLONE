namespace IndustrialExpansionMRLONE.Economy
{
    public class MarketProductData
    {
        public string ProductId { get; set; } = "";
        public float Demand { get; set; } = 1f;
        public float Supply { get; set; } = 1f;
        public bool IsTrending { get; set; }
    }
}
