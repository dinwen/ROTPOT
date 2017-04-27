using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotpot.src.level.entities
{
    class ParticleLeaf : EntityParticle
    {

        private Rectangle textureRect;
        private float depth;
        private float rotation;
        private float rotationSpeed;

        public ParticleLeaf(Vector2 Position)
        {
            position = Position;

            duration = rdn.Next(200, 280);

            velocity = new Vector2((float)rdn.NextDouble() * 2 - 1f, (float)rdn.NextDouble() * 1.5f + 1);

            textureRect = new Rectangle(rdn.Next(4) * 64, 0, 64, 64);
            depth = 0.05f + (float)(rdn.NextDouble() * 0.1f);
            rotationSpeed = (float)rdn.NextDouble() * 0.03f;
        }

        public override void Update(GameTime gameTime)
        {
            rotation += rotationSpeed;

            if (--duration <= 0)
            {
                Remove();
            }

            position += velocity;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("leaf"), position, textureRect, new Color(Color.White, duration / 60f), rotation, new Vector2(32, 32), 1, SpriteEffects.None, depth);
        }

    }
}
