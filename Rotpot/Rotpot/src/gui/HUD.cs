using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            x = 0;
            y = 30;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(resourceManager.images.GetImage("powerbar"), new Vector2(164 + x, 151 + y) + Main.camera.Position, new Rectangle(0, 0, (int)((EntityLiving)level.entityManager.GetEntity(0)).GetStrength(), 36), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);
            batch.Draw(resourceManager.images.GetImage("healthbar"), new Vector2(216 + x, 110 + y) + Main.camera.Position, new Rectangle(0, 0, (int)((EntityLiving)level.entityManager.GetEntity(0)).GetHealth(), 36), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);
            batch.Draw(resourceManager.images.GetImage("interface"), new Vector2(x, y) + Main.camera.Position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1f);
        }
    }
}
