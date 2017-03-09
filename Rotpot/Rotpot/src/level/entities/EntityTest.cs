using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class EntityTest : Entity
    {

        private Texture2D sprite;

        public EntityTest(Level level, Vector2 pos)
        {
            this.level = level;
            this.position = pos;
            sprite = level.resourceManager.images.GetImage("grass");
        }

        public override void Update()
        {
            position.X++;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(sprite, position, Color.White);
        }

    }
}
