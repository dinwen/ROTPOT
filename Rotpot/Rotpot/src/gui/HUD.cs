using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rotpot.src.level.entities;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.gui
{
    public class HUD
    {
        public int x, y;
        Level level;
  

        ResourceManager resourceManager;

        public HUD(ResourceManager resourceManager, Level level)
        {
            this.level = level;
            this.resourceManager = resourceManager;
            Main.score = 0;
            x = 0;
            y = 30;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Main.state = Main.STATE.Menu;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (level.GetPlayer() != null)
            {
                batch.Draw(resourceManager.images.GetImage("powerbar"), new Vector2(164 + x, 151 + y) + Main.camera.Position, new Rectangle(0, 0, (int)(level.GetPlayer().GetStrength() / 100f * 339), 36), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);
                batch.Draw(resourceManager.images.GetImage("healthbar"), new Vector2(216 + x, 110 + y) + Main.camera.Position, new Rectangle(0, 0, (int)(level.GetPlayer().GetHealth()), 36), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);
                batch.Draw(resourceManager.images.GetImage("interface"), new Vector2(x, y) + Main.camera.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1f);
                batch.DrawString(ResourceManager.font, "Score: " + Main.score, new Vector2(1700, 100) + Main.camera.Position, Color.Honeydew, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1f);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                batch.Draw(resourceManager.images.GetImage("ExitSign"), new Vector2(x, y) + Main.camera.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1f);
            }

        }
    }
}
