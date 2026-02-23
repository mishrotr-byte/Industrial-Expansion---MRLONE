using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace IndustrialExpansionMRLONE.UI
{
    public class UIProgressBar
    {
        public Rectangle Area;
        public float Progress;

        public void Draw(SpriteBatch b)
        {
            b.Draw(Game1.staminaRect, Area, Color.DarkGray);
            b.Draw(Game1.staminaRect,
                new Rectangle(Area.X, Area.Y, (int)(Area.Width * Progress), Area.Height),
                Color.LimeGreen);
        }
    }
}
