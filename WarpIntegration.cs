using StardewModdingAPI;
using StardewValley;
using StardewModdingAPI.Events;

namespace IndustrialExpansionMRLONE.City
{
    public class WarpIntegration
    {
        public WarpIntegration(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (e.Button == SButton.F8)
            {
                Game1.warpFarmer("MRLONE", 10, 10, false);
            }
        }
    }
}
