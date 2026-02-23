using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using Microsoft.Xna.Framework;

namespace IndustrialExpansionMRLONE
{
    public class CityManager
    {
        private readonly IModHelper Helper;

        public CityManager(IModHelper helper)
        {
            Helper = helper;
        }

        public void LoadCity()
        {
            if (!ModEntry.Config.EnableCity)
                return;

            if (Game1.getLocationFromName("MRLONE") != null)
                return;

            var map = Helper.ModContent.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("assets/maps/MRLONE.tmx");

            GameLocation city = new GameLocation("assets/maps/MRLONE.tmx", "MRLONE");
            Game1.locations.Add(city);

            ModEntry.Instance.Monitor.Log("MRLONE city loaded.", LogLevel.Info);
        }
    }
}
