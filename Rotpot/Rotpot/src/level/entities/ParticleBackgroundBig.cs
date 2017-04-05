using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class ParticleBackgroundBig : EntityParticle
    {
        public ParticleBackgroundBig(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(20, 100);
            velocity = new Vector2(rdn.Next(5) - 2, -(rdn.Next(3) + 1));
        }
        public override void Update(GameTime gameTime)
        {
            if (--duration <= 0)
            {
                Remove();
            }

            position += velocity;
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("circlebig"), position, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.05f);
        }
    }
}
