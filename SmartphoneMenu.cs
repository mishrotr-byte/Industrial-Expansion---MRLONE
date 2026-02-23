using StardewValley;
using StardewValley.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IndustrialExpansionMRLONE.Phone
{
    public class SmartphoneMenu : IClickableMenu
    {
        private List<PhoneApp> apps = new();

        public SmartphoneMenu()
            : base(Game1.viewport.Width / 2 - 300,
                   Game1.viewport.Height / 2 - 500,
                   600, 900,
                   true)
        {
            InitializeApps();
        }

        private void InitializeApps()
        {
            apps.Add(new PhoneApp("Factory", new Rectangle(xPositionOnScreen + 100, yPositionOnScreen + 200, 150, 150),
                () => Game1.activeClickableMenu = new Apps.FactoryApp()));

            apps.Add(new PhoneApp("Contracts", new Rectangle(xPositionOnScreen + 350, yPositionOnScreen + 200, 150, 150),
                () => Game1.activeClickableMenu = new Apps.ContractsApp()));

            apps.Add(new PhoneApp("Reputation", new Rectangle(xPositionOnScreen + 100, yPositionOnScreen + 400, 150, 150),
                () => Game1.activeClickableMenu = new Apps.ReputationApp()));

            apps.Add(new PhoneApp("Finance", new Rectangle(xPositionOnScreen + 350, yPositionOnScreen + 400, 150, 150),
                () => Game1.activeClickableMenu = new Apps.FinanceApp()));
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            foreach (var app in apps)
                app.Click(x, y);
        }

        public override void draw(SpriteBatch b)
        {
            Game1.drawDialogueBox(xPositionOnScreen, yPositionOnScreen, width, height, false, true);

            b.DrawString(Game1.dialogueFont,
                "📱 MRLONE OS",
                new Vector2(xPositionOnScreen + 200, yPositionOnScreen + 80),
                Color.Black);

            foreach (var app in apps)
                app.Draw(b);

            base.draw(b);
            drawMouse(b);
        }
    }
}
