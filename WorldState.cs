namespace IndustrialExpansionMRLONE.Systems
{
    public class WorldState
    {
        public WorldEventData? ActiveEvent { get; set; }
        public MarketingCampaignData? ActiveCampaign { get; set; }

        public float CorporatePressure { get; set; } = 0f;
        public int WarIntensity { get; set; } = 0;
    }
}
