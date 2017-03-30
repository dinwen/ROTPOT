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
        public ParticleDust(Vector2 Position)
        {
            position = Position;
        }
        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("star"), position, Color.White);
        }
    }
}
