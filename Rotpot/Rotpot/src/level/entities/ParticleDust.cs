using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rotpot.src.level.entities
{
    class ParticleDust:EntityParticle
    {

        private float scale;

        public ParticleDust(Vector2 Position, Vector2 direction, float scale)
        {
            position = Position;
            velocity = new Vector2((float)(rdn.NextDouble() - 0.5f) * 2, (float)(rdn.NextDouble() - 0.8f)) + direction;

            duration = 400 + rdn.Next(0, 100);
            this.scale = scale;
        }
        public override void Update(GameTime gameTime)
        {
            velocity *= 0.995f;

            if (--duration <= 0) Remove();
            position += velocity;
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("smoke"), position, null, new Color(0.35f, 0.1f, 0.1f, 0.1f), 0, new Vector2(128, 128), scale, SpriteEffects.None, 0.05f);
        }
    }
}
