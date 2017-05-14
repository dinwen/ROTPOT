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

            duration = rdn.Next(60, 80);

            velocity = new Vector2((float)(rdn.NextDouble() - 0.5f) * 4, (float)(rdn.NextDouble() - 0.8f) * 4);
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
            //batch.Draw(level.resourceManager.images.GetImage("star"), position, new Color(Color.White, duration / 60f));

            batch.Draw(level.resourceManager.images.GetImage("particle"), position, null, new Color(Color.White, duration / 60f), 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.05f);
        }
    }
}
