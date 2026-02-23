namespace IndustrialExpansionMRLONE.Factory
{
    public class Contract
    {
        public string Id { get; set; } = "";
        public string ProductId { get; set; } = "";
        public int RequiredAmount { get; set; }
        public int Reward { get; set; }
        public int DeadlineDay { get; set; }
        public bool Completed { get; set; }
        public bool Failed { get; set; }
    }
}
