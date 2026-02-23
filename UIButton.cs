using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace IndustrialExpansionMRLONE.UI
{
    public class UIButton
    {
        public Rectangle Bounds;
        public string Text;
        public System.Action OnClick;

        public UIButton(Rectangle bounds, string text, System.Action onClick)
        {
            Bounds = bounds;
            Text = text;
            OnClick = onClick;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(Game1.staminaRect, Bounds, Color.DarkSlateGray);
            b.DrawString(Game1.smallFont,
                Text,
                new Vector2(Bounds.X + 10, Bounds.Y + 8),
                Color.White);
        }

        public void Click(int x, int y)
        {
            if (Bounds.Contains(x, y))
                OnClick?.Invoke();
        }
    }
}
