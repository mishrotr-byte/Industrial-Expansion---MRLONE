namespace IndustrialExpansionMRLONE.Systems
{
    public class MarketingCampaignData
    {
        public string Type { get; set; } = "";
        public int RemainingDays { get; set; }
        public float DemandBoost { get; set; }
        public float ReputationBoost { get; set; }
        public int Cost { get; set; }
    }
}
