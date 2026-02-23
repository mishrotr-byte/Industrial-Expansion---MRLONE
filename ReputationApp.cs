using StardewValley;
using StardewValley.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IndustrialExpansionMRLONE.Phone.Apps
{
    public class ReputationApp : IClickableMenu
    {
        public ReputationApp()
            : base(Game1.viewport.Width / 2 - 400,
                   Game1.viewport.Height / 2 - 300,
                   800, 600,
                   true)
        {
        }

        public override void draw(SpriteBatch b)
        {
            var rep = ModEntry.Instance.Reputation.Get();

            Game1.drawDialogueBox(xPositionOnScreen, yPositionOnScreen, width, height, false, true);

            int y = yPositionOnScreen + 150;

            b.DrawString(Game1.smallFont, $"Level: {rep.Level}", new Vector2(xPositionOnScreen + 100, y), Color.Black);
            y += 40;
            b.DrawString(Game1.smallFont, $"Influence: {rep.Influence}", new Vector2(xPositionOnScreen + 100, y), Color.Black);
            y += 40;
            b.DrawString(Game1.smallFont, $"Market Share: {rep.MarketShare}%", new Vector2(xPositionOnScreen + 100, y), Color.Black);
            y += 40;
            b.DrawString(Game1.smallFont, $"Trust: {rep.Trust}", new Vector2(xPositionOnScreen + 100, y), Color.Black);

            base.draw(b);
            drawMouse(b);
        }
    }
}
