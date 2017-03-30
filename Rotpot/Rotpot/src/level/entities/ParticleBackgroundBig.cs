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

            duration = rdn.Next(15, 20);
        }
        public override void Update(GameTime gameTime)
        {
            if (--duration <= 0)
            {
                Remove();
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("circlebig"), position, Color.White);
        }
    }
}
