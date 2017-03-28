using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class ParticleStar:EntityParticle
    {
        public ParticleStar(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(10, 50);

            velocity = new Vector2(rdn.Next(-2,2),rdn.Next(-5,1));
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
            batch.Draw(level.resourceManager.images.GetImage("star"), position, Color.White);
        }
    }
}
