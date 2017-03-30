using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class ParticleBackground:EntityParticle
    {
        public ParticleBackground(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(5, 60);
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
            batch.Draw(level.resourceManager.images.GetImage("circle3"), position, Color.White);
        }
    }
}
