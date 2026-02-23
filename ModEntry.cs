using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using HarmonyLib;

namespace IndustrialExpansionMRLONE
{
    public class ModEntry : Mod
    {
        internal static ModEntry Instance;
        internal static ModConfig Config;

        internal CityManager CityManager;
        internal FactoryManager FactoryManager;
        internal EconomyManager EconomyManager;
        internal ReputationSystem ReputationSystem;

        public override void Entry(IModHelper helper)
        {
            Instance = this;
            Config = helper.ReadConfig<ModConfig>();

            CityManager = new CityManager(helper);
            FactoryManager = new FactoryManager(helper);
            EconomyManager = new EconomyManager(helper);
            ReputationSystem = new ReputationSystem(helper);

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
            helper.Events.GameLoop.DayStarted += OnDayStarted;

            var harmony = new Harmony(ModManifest.UniqueID);
            harmony.PatchAll();
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            Monitor.Log("IndustrialExpansionMRLONE loaded.", LogLevel.Info);
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            CityManager.LoadCity();
            EconomyManager.LoadData();
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            EconomyManager.ProcessDailyEconomy();
            FactoryManager.ProcessProduction();
        }
    }

    public class ModConfig
    {
        public bool EnableCity { get; set; } = true;
        public bool EnableEconomySystem { get; set; } = true;
        public int BaseTaxPercent { get; set; } = 12;
        public int FriendshipTaxPercent { get; set; } = 8;
        public bool DebugMode { get; set; } = false;
    }
}
