using StardewValley;
using StardewValley.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IndustrialExpansionMRLONE.Factory;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialExpansionMRLONE.UI
{
    public class FactoryMenu : IClickableMenu
    {
        private List<UIButton> buttons = new();
        private string currentTab = "Overview";

        public FactoryMenu()
            : base(Game1.viewport.Width / 2 - 500,
                   Game1.viewport.Height / 2 - 350,
                   1000, 700,
                   true)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            buttons.Add(new UIButton(
                new Rectangle(xPositionOnScreen + 40, yPositionOnScreen + 80, 150, 40),
                "Overview",
                () => currentTab = "Overview"));

            buttons.Add(new UIButton(
                new Rectangle(xPositionOnScreen + 200, yPositionOnScreen + 80, 150, 40),
                "Production",
                () => currentTab = "Production"));

            buttons.Add(new UIButton(
                new Rectangle(xPositionOnScreen + 360, yPositionOnScreen + 80, 150, 40),
                "Contracts",
                () => currentTab = "Contracts"));
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            foreach (var b in buttons)
                b.Click(x, y);
        }

        public override void draw(SpriteBatch b)
        {
            Game1.drawDialogueBox(xPositionOnScreen, yPositionOnScreen, width, height, false, true);

            foreach (var button in buttons)
                button.Draw(b);

            DrawContent(b);

            base.draw(b);
            drawMouse(b);
        }

        private void DrawContent(SpriteBatch b)
        {
            if (currentTab == "Overview")
            {
                b.DrawString(Game1.smallFont,
                    "Factory Overview",
                    new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 150),
                    Color.Black);
            }

            if (currentTab == "Production")
            {
                var products = ModEntry.Instance.Factory.GetProducts();
                int y = 180;
                foreach (var p in products)
                {
                    b.DrawString(Game1.smallFont,
                        $"{p.Name} - {p.Price}g",
                        new Vector2(xPositionOnScreen + 50, y),
                        Color.DarkBlue);
                    y += 35;
                }
            }

            if (currentTab == "Contracts")
            {
                var contracts = ModEntry.Instance.FactoryContractManager.GetContracts();
                int y = 180;

                foreach (var c in contracts)
                {
                    b.DrawString(Game1.smallFont,
                        $"Deliver {c.RequiredAmount} units | Reward: {c.Reward}g | Deadline: {c.DeadlineDay}",
                        new Vector2(xPositionOnScreen + 50, y),
                        c.Failed ? Color.Red : Color.DarkGreen);

                    y += 40;
                }
            }
        }
    }
}
