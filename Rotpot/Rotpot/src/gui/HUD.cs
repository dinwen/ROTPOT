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
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch)
        {

            batch.Draw(resourceManager.images.GetImage("powerbar"), new Vector2(164 + x, 279 + y), new Rectangle(0, 0, (int)((EntityLiving)level.entityManager.GetEntity(0)).GetStrength(), 36), Color.White);
            batch.Draw(resourceManager.images.GetImage("healthbar"), new Vector2(216 + x, 238 + y), new Rectangle(0, 0, (int)((EntityLiving)level.entityManager.GetEntity(0)).GetHealth(), 36), Color.White);
            batch.Draw(resourceManager.images.GetImage("interface"), new Vector2(x, y), Color.White);

        }
    }
}
