using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace IndustrialExpansionMRLONE.Phone
{
    public class PhoneApp
    {
        public string Name;
        public Rectangle Area;
        public System.Action OnOpen;

        public PhoneApp(string name, Rectangle area, System.Action onOpen)
        {
            Name = name;
            Area = area;
            OnOpen = onOpen;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(Game1.staminaRect, Area, Color.DarkSlateBlue);
            b.DrawString(Game1.smallFont,
                Name,
                new Vector2(Area.X + 20, Area.Y + 60),
                Color.White);
        }

        public void Click(int x, int y)
        {
            if (Area.Contains(x, y))
                OnOpen?.Invoke();
        }
    }
}
