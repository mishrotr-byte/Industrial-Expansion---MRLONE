namespace IndustrialExpansionMRLONE.Systems
{
    public class WorldEventData
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int RemainingDays { get; set; }

        public float DemandModifier { get; set; } = 1f;
        public float TaxModifier { get; set; } = 1f;
        public float ReputationModifier { get; set; } = 1f;
    }
}
