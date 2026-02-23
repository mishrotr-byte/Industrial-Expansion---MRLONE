namespace IndustrialExpansionMRLONE.World
{
    public class WorldEvent
    {
        public string Name { get; set; } = "";
        public int RemainingDays { get; set; }
        public float GlobalDemandModifier { get; set; } = 1f;
        public float TaxModifier { get; set; } = 1f;
    }
}
