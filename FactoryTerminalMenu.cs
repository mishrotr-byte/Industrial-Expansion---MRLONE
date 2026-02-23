using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using System;

namespace IndustrialExpansionMRLONE
{
    public class FactoryTerminalMenu : IClickableMenu
    {
        private string productName = "";
        private string productType = "";
        private int price = 100;
        private int rarity = 1;
        private int productionDays = 1;

        public FactoryTerminalMenu()
            : base(Game1.viewport.Width / 2 - 400,
                   Game1.viewport.Height / 2 - 300,
                   800, 600,
                   true)
        {
        }

        public override void draw(SpriteBatch b)
        {
            Game1.drawDialogueBox(xPositionOnScreen, yPositionOnScreen, width, height, false, true);

            SpriteFont font = Game1.smallFont;

            b.DrawString(font, "🏭 Заводской терминал", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 50), Color.Black);
            b.DrawString(font, $"Название: {productName}", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 120), Color.Black);
            b.DrawString(font, $"Тип: {productType}", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 160), Color.Black);
            b.DrawString(font, $"Цена: {price}", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 200), Color.Black);
            b.DrawString(font, $"Редкость: {rarity}", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 240), Color.Black);
            b.DrawString(font, $"Дни производства: {productionDays}", new Vector2(xPositionOnScreen + 50, yPositionOnScreen + 280), Color.Black);

            base.draw(b);
            drawMouse(b);
        }

        public override void receiveKeyPress(Microsoft.Xna.Framework.Input.Keys key)
        {
            if (key == Microsoft.Xna.Framework.Input.Keys.Enter)
            {
                CreateProduct();
                Game1.exitActiveMenu();
            }
            base.receiveKeyPress(key);
        }

        private void CreateProduct()
        {
            var product = new CustomProduct
            {
                Id = Guid.NewGuid().ToString(),
                Name = string.IsNullOrWhiteSpace(productName) ? "Новый продукт" : productName,
                Type = "General",
                Price = price,
                Rarity = rarity,
                ProductionDays = productionDays
            };

            ModEntry.Instance.FactoryManager.AddProduct(product);

            Game1.addHUDMessage(new HUDMessage("✅ Продукт создан!", 2));
        }
    }
}
