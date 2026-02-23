namespace IndustrialExpansionMRLONE
{
    public class BrandSystem
    {
        public int BrandLevel { get; private set; } = 1;
        public int Experience { get; private set; } = 0;

        public void AddExperience(int amount)
        {
            Experience += amount;

            if (Experience > BrandLevel * 100)
            {
                BrandLevel++;
                Experience = 0;
            }
        }
    }
}
